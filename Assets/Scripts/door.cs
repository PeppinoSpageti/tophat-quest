using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            if (FindFirstObjectByType<PizzaTime>().isPizzaTime == true) 
            {
            //add level finish code HERE
            }
        }
    }
}
