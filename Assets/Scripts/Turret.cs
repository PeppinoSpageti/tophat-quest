using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float shotTime;
    public float timer;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > shotTime)
        {
            timer = 0;
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }
}
