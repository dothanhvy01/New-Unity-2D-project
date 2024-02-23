using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grab_Item : MonoBehaviour
{
    [SerializeField] private LayerMask itemLayer;
    public GameObject grabPos;
    public bool grabbing = false;
    public float hookSpeed = 1f;

    private bool touching = false;
    private Vector2 fistPos;
    private BoxCollider2D cl;

    // Start is called before the first frame update
    void Start()
    {
        fistPos = transform.position;
        cl = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement_down = Vector2.down * hookSpeed * Time.deltaTime;

        if (grabbing && !touching)
        {
            transform.Translate(movement_down);
            Collider2D collider = Physics2D.OverlapBox(cl.bounds.center, cl.bounds.size, 0f, itemLayer);

            if (collider != null)
            {
                touching = true;
                //collider.transform.position = grabPos.transform.position;
                collider.transform.parent = grabPos.transform;
            }
        }
        if (grabbing && touching)
        {
            MoveBack();
        }
    }

    void MoveBack()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, fistPos, hookSpeed * Time.deltaTime);

        transform.position = newPosition;
    }
}
