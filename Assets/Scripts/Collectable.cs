using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject container;
    public float rotationSpeed = 180f;

    [Header("Gameplay")]
    public int score = 1;

    void Update()
    {
     container.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
