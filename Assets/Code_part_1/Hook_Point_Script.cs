using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Point_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color c = transform.GetComponent<SpriteRenderer>().color;
        c.a = 0f;
        transform.GetComponent<SpriteRenderer>().color = c; 
    }
}
