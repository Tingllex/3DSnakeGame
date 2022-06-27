using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDestructionBlock : MonoBehaviour
{
    public GameObject AnvilPrefab;

    public Transform BorderTop;
    public Transform BorderLeft;
    public Transform BorderRight;
    public Transform BorderBottom;
    void Start()
    {
        InvokeRepeating("Spawn", 10, 4);
    }

    void Spawn()
    {
        int x = (int)Random.Range(BorderLeft.position.x + 1, BorderRight.position.x - 1);
        int y = 20;
        int z = (int)Random.Range(BorderBottom.position.z + 1, BorderTop.position.z - 1);

        Instantiate(AnvilPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}
