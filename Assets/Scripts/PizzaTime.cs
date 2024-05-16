using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaTime : MonoBehaviour
{
    public Text timeText;
    public bool isPizzaTime = false;
    public float timer;
    public DemonVoid myDemonVoid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPizzaTime)
        {
            timeText.enabled = true;
            if(timer > 0 )
            {
                timer -= Time.deltaTime;
                timeText.text = timer.ToString();
            }
            else
            {
                timeText.text = "Closing Time!!!";
                myDemonVoid.gameObject.SetActive(true);
                //Spawn bad guy
            }
        }
    }
}
