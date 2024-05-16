using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DemonVoid : MonoBehaviour
{
    public Transform myPlayerTransform;
    public float speed;
    public Sprite deadSprite;
    // Start is called before the first frame update
    void Start()
    {
        myPlayerTransform = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure the target is set
        if (myPlayerTransform != null)
        {
            // Calculate the new position
            Vector2 newPosition = Vector2.MoveTowards(transform.position, myPlayerTransform.position, speed * Time.deltaTime);
            // Update the sprite's position
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            transform.localScale = Vector3.one * 5;
            collision.GetComponent<SpriteRenderer>().sprite = deadSprite;
            collision.GetComponent<Animator>().enabled = false;
            collision.GetComponent<Player>().enabled = false;
        }
    }
}

