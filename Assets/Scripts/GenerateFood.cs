using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFood : MonoBehaviour
{
    public GameObject FoodPrefab;

    public Transform BorderTop;
    public Transform BorderLeft;
    public Transform BorderRight;
    public Transform BorderBottom;
    void Start()
    {
        // Spawn food every 4 seconds, starting in 3
        InvokeRepeating("Spawn", 3, 4);
    }

    void Spawn()
    {
        int x = (int)Random.Range(BorderLeft.position.x + 1, BorderRight.position.x - 1);
        int y = 0;
        int z = (int)Random.Range(BorderBottom.position.z + 1, BorderTop.position.z - 1);

        Instantiate(FoodPrefab, new Vector3(x, y, z), Quaternion.identity);
    }

}
