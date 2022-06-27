using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Snake SnakeObject = collision.collider.GetComponent<Snake>();
        Collider BorderCollider = GetComponent<Collider>();
        gameObject.SetActive(false);
        BorderCollider.enabled = false;
    }
}
