using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Position
{
    Top,
    Bottom
}

public class LedgeCollider : MonoBehaviour
{
    [SerializeField] Position pos;
    [SerializeField] BoxCollider top;
    [SerializeField] BoxCollider bot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (pos == Position.Bottom)
            {
                top.isTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (pos == Position.Top)
            {
                top.isTrigger = false;
            }
        }
    }
}
