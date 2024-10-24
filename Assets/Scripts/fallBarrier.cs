using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallBarrier : MonoBehaviour
{
    public Transform respawnTransform;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.tag == "Player")
        {
            collision.transform.position = respawnTransform.position;
        }
    }

}
