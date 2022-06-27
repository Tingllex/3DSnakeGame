using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    private IEnumerator OnCollisionEnter(Collision collision)
    {
        Collider AnvilCollider = GetComponent<Collider>();
        yield return new WaitForSeconds(1);
        AnvilCollider.enabled = false;
        gameObject.SetActive(false);
    }
}
