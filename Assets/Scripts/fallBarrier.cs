using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBarrier : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
        {
            collision.transform.position = new Vector3(-72.5f, 37.5f, 0f);
        }
    }

}
