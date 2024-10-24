using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public PizzaTime myPizzaTime;
    public bool isPizzaTimeActive = false;
    private void Start()
    {
        myPizzaTime = FindFirstObjectByType<PizzaTime>();
    }
    private void Update()
    {
        isPizzaTimeActive = myPizzaTime.isPizzaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player")
        {
            Debug.Log("PlayerTouchDoor");
            if (isPizzaTimeActive== true)
            {
                Debug.Log("MenuShouldHaveLoaded");
                SceneManager.LoadScene("Main menu");
            }
        }
    }
}
