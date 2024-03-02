using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;

public class Key_Script : MonoBehaviour
{

    public int clickLimit;
    public List<Transform> doors;
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
        boxNumber = Random.Range(1, clickLimit);
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
            int RandomNuumber = Random.Range(0, clickLimit);
            currentClick++;
            if (RandomNuumber == boxNumber || currentClick == clickLimit)
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
        Vector2 curvePosition = Vector2.Lerp(transform.position, doors[0].position, t);
        transform.position = curvePosition;
        if (Vector3.Distance(transform.position, doors[0].position) <= 0.5f)
        {
            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].GetComponent<Door_Scipt>().OpenDoor();
                isOpen = false;
                Destroy(transform.gameObject);
            }
        }
    }
}
