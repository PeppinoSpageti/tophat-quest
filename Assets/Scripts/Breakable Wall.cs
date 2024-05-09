using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("collided with player");
            Player player = collision.transform.GetComponent<Player>();
            Debug.Log("SuperSpeed == " + player.isSuperSpeedActive);
            if (player.isSuperSpeedActive == true)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
