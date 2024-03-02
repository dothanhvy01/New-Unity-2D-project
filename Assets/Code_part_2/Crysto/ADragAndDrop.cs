using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADradAndDrop : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;
    public GameObject itemReact;
    public Move_Item moveItem;
    
    public abstract void Update();
    public abstract void Start();
   

    private void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
       
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    public bool IsInDropArea(string tagName)
    {
       
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag(tagName))
            {
                return true;
            }
        }
        return false;
    }
   
}
