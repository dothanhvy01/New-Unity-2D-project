using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_Land : MonoBehaviour
{
    public float floatSpeed = 0.5f; 
    public float floatHeight = 0.5f; 
    public float amplitude = 0.5f; 
    public bool vertical = true; 
    private Vector3 startPos;
    public bool fly = true;

    void Start()
    {
        startPos = transform.position;
    }
    public bool isFly()
    {
        return fly;
    }
    
    void Update()
    {
      
        if (fly)
        {
            float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * amplitude;
            Vector3 newPos = new Vector3(startPos.x, newY, startPos.z);
            if (vertical)
            {
                transform.position = newPos;
            }
            else
            {
                transform.position = new Vector3(newPos.x, startPos.y, newPos.z);
            }
        }
        else
        {
            return;
        }
    }
   
}
