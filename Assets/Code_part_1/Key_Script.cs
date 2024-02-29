using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class Key_Script : MonoBehaviour
{

    public int boxCount;
    public Transform door;
    public float keySpeed = 2f;

    private int boxNumber;
    private SpriteRenderer sr;
    private float t = 0f;
    private Vector2 clickPos;
    private bool isOpen = false;
    private int currentClick = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxNumber = Random.Range(1, boxCount);
        sr = transform.GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            KeyMove();
        }
    }

    public void RandomOpen(Vector2 BoxPos)
    {
            int RandomNuumber = Random.Range(0, boxCount);
            currentClick++;
            if (RandomNuumber == boxNumber || currentClick == boxCount)
            {
                clickPos = BoxPos;
                isOpen = true;
            }
    }

    private void KeyMove()
    {
        sr.enabled = true;
        transform.position = clickPos;
        t += Time.deltaTime * keySpeed;
        //t = Mathf.Clamp01(t);
        Vector2 curvePosition = Vector2.Lerp(transform.position, door.position, t);
        transform.position = curvePosition;
        if (Vector3.Distance(transform.position, door.position) <= 0.5f)
        {
            door.GetComponent<Door_Scipt>().OpenDoor();
            isOpen = false;
            Destroy(transform.gameObject);
        }
    }
}
