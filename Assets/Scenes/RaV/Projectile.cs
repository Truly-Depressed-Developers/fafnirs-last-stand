using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 movement;
    //public float arrowSpeed;
    void Start()
    {
        Debug.Log("Spawned arrow");
    }

    void Update()
    {
        gameObject.transform.position += movement;
    }
}
