using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roket : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }
}