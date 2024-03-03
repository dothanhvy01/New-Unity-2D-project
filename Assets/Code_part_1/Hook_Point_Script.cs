using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Point_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().sprite = null;
    }
}
