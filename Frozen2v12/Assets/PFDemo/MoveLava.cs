using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLava : MonoBehaviour
{
    public float speed;
    public bool direction;
    public float maxtimer;
    private float timer;
    public void Start()
    {
        if (direction == false)
        {
            timer = maxtimer;
        }
        else timer = 0;
    }
    public void Update()
    {
        if (direction == true)
        {
            timer += Time.deltaTime;
        }
        else timer -= Time.deltaTime;
        if (timer<=0)
        {
            direction = true;
        }
        if (timer>=maxtimer)
        {
            direction = false;
        }
        if (direction == true)
        {
            transform.position=transform.position + new Vector3(0, speed,0);
        } else transform.position = transform.position - new Vector3(0, speed, 0);
    }
}
