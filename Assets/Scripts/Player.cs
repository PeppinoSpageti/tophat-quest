using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float tauntTime;
    public Sprite mySecondSprite;
    public float speed;
    public float airAcceleration;
    public float jumpHeight;
    public bool isOnGround;
    public Animator computerScreen;
    public Sprite tauntSprite;
    public bool tauntIsReady;
    public Animator playerAnimator;
    public SpriteRenderer myspriteRenderer;

    public float maxFallSpeed = 10f; // Adjust as needed
    public float maxSpeed = 10f; // Adjust as needed
    public float higherDrag = 5f; // Adjust as needed
    public float horizontalDrag = 0.5f; // Adjust as needed
    public float superMaxSpeed = 15f; // Adjust as needed, higher than maxSpeed
    public bool isSuperSpeedActive = false;

    

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myspriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void playBurntScreen()
    {
        computerScreen.SetTrigger("Player Burnt");

    }
    // Update is called once per frame

    void Update()
    {
        float moveHorizontal = 0;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveHorizontal += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveHorizontal -= 1;
        }

        // Apply a force for movement
        if (moveHorizontal != 0 && isOnGround)
        {
            Vector2 force = new Vector2(moveHorizontal * speed * Time.deltaTime, 0);
            myRigidBody.AddForce(force);
        }
        else if (moveHorizontal != 0)
        {
            Vector2 force = new Vector2(moveHorizontal * airAcceleration * Time.deltaTime, 0);
            myRigidBody.AddForce(force);
        }
        else if (isOnGround)
        {
            // Apply horizontal drag only when there is no horizontal input and not in super speed state
            float newVelocityX = myRigidBody.velocity.x * (1 - Time.deltaTime * horizontalDrag);
            myRigidBody.velocity = new Vector2(newVelocityX, myRigidBody.velocity.y);
        }

        // Check if velocity exceeds maxSpeed and activate super speed state
        if (Mathf.Abs(myRigidBody.velocity.x) > maxSpeed && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            myspriteRenderer.color = Color.white; // Change sprite color to red
        }

        // Handle super speed state
        if (isSuperSpeedActive)
        {
            playerAnimator.SetBool("Mach2", true);
            // Clamp the velocity to the super maximum speed
            float clampedX = Mathf.Clamp(myRigidBody.velocity.x, -superMaxSpeed, superMaxSpeed);
            myRigidBody.velocity = new Vector2(clampedX, myRigidBody.velocity.y);

            // Optional: Reset to normal state based on some condition, e.g., slowing down below maxSpeed
            if (Mathf.Abs(myRigidBody.velocity.x) < maxSpeed)
            {
                isSuperSpeedActive = false;
                myspriteRenderer.color = Color.white; // Reset sprite color
            }
            if(myRigidBody.velocity.x < 0)
            {
                myspriteRenderer.flipX = true;
            }
            else
            {
                myspriteRenderer.flipX = false;
            }
        }
        else
        {
            // Clamp the horizontal velocity to the normal maximum speed
            float clampedX = Mathf.Clamp(myRigidBody.velocity.x, -maxSpeed, maxSpeed);
            myRigidBody.velocity = new Vector2(clampedX, myRigidBody.velocity.y);
            playerAnimator.SetBool("Mach2", false);
        }

        // Remaining logic for jumping and taunting
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            myRigidBody.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.C) && tauntIsReady)
        {
            playerAnimator.enabled = false;
            myspriteRenderer.sprite = tauntSprite;
            myRigidBody.isKinematic = true;
            myRigidBody.velocity = Vector2.zero;
            Invoke("PlayerReset", tauntTime);
            tauntIsReady = false;
            Invoke("tauntWait", 1);
        }
    }
    public void PlayerReset()
    {
        playerAnimator.enabled = true;
        myRigidBody.isKinematic = false;
    }
    public void tauntWait()
    {
        tauntIsReady = true;
    }
}
