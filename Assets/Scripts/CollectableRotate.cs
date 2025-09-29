using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 1; // Speed of rotation of coin
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0,Space.World); // Rotate the coin around the Y-axis
    }
}
