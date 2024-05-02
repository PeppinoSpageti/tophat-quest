using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float tauntTime;
    public Sprite mySecondSprite;
    public float speed;
    public float jumpHeight;
    public bool isOnGround;
    public Animator computerScreen;
    public Sprite tauntSprite;
    public bool tauntIsReady;
    public Animator playerAnimator;
    public SpriteRenderer myspriteRenderer;
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround == true)
            {
                myRigidBody.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (tauntIsReady == true)
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
