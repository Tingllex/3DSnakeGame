using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Collider FoodCollider = GetComponent<Collider>();
        gameObject.SetActive(false);
        FoodCollider.enabled = false;
    }
}
