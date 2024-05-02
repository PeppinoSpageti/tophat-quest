using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float mySpeed;
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * mySpeed * Time.deltaTime;   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // collision.transform.position = new Vector3(-74, 36.3f, 0);
            collision.GetComponent<Player>().playBurntScreen();
        }
    }
}
