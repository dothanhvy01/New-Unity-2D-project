using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grab_Item : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayer;

    [HideInInspector]public bool touching = false;
    private BoxCollider2D cl;

    // Start is called before the first frame update
    void Start()
    {
        cl = transform.GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {

        if (!touching)
        {
            Collider2D colliderBox = Physics2D.OverlapBox(cl.bounds.center, cl.bounds.size, 0f, itemLayer);

            if (colliderBox != null)
            {
                touching = true;
                colliderBox.transform.parent = transform;
            }
        }
    }
}
