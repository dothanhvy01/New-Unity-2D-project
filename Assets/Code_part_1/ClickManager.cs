using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public LayerMask clickableLayer;

    private GameObject messBox;
    private float clickCooldown = 1.5f;
    private float lastClickTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        messBox = GameObject.Find("MessBox");
        messBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastClickTime >= clickCooldown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit;


            lastClickTime = Time.time;
            if (hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, clickableLayer))
            {
                Debug.Log("Click: " + hit.collider.gameObject.name);
            }
            else
            {
                messBox.SetActive(true);

                Invoke("Close", 1.5f);
            }
        }
    }

    void Close()
    {
        messBox.SetActive(false);
    }
}
