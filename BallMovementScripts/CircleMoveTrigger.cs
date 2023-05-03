using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMoveTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You Passed the Block");
    }
}
