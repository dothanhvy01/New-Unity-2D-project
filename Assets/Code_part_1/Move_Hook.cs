using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Move_Hook : MonoBehaviour
{
    [SerializeField] Transform[] movePoss;
    public float hookSpeed = 1f;
    public bool moving = false;

    private bool touching;
    private Grab_Item gi;
    private Vector2 initialPos;
    private bool back = false;
    private int currentIndex = 0;

    void Start()
    {
        gi = transform.GetComponent<Grab_Item>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movePoss != null && movePoss.Length > 0 && moving)
        {
            currentIndex = 0;
            StartCoroutine(MoveToNextPosition());
            moving = false;
        }
        if (touching || back)
        {
            StartCoroutine(MoveBackToNextPosition());
            back = false;
        }
    }

    private void FixedUpdate()
    {
        touching = gi.touching;
    }
    IEnumerator MoveToNextPosition()
    {
        while (currentIndex < movePoss.Length)
        {
            if (!touching)
            {
                Vector2 direction = movePoss[currentIndex].position - transform.position;
                float distance = direction.magnitude;
                //Vector2 targetPosition = movePoss[currentIndex].position;
                //while ((Vector2)transform.position != targetPosition)
                //{
                //    transform.Translate(direction.normalized * hookSpeed * Time.deltaTime);
                //    yield return null;
                //}
                transform.Translate(direction.normalized * hookSpeed * Time.deltaTime);

                if (distance < 0.1f)
                {
                    currentIndex++;
                }
            }
            else
            {
                back = true;
                currentIndex = movePoss.Length - 2;
                break;
            }
            yield return null;

            if (currentIndex == movePoss.Length - 1)
            {
                back = true;
                currentIndex = movePoss.Length - 2;
                break;
            }

            //currentIndex++;
        }
    }

    IEnumerator MoveBackToNextPosition()
    {
        if (back)
        {
            while (currentIndex >= 0)
            {
                Vector2 targetPosition = movePoss[currentIndex].position;
                while ((Vector2)transform.position != targetPosition)
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetPosition, hookSpeed * Time.deltaTime);
                    yield return null;
                }
                if (currentIndex == 0)
                {
                    yield return MoveToBasePosition();
                }
                currentIndex--;
            }
        }
    }

    IEnumerator MoveToBasePosition()
    {
        while ((Vector2)transform.position != initialPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPos, hookSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
