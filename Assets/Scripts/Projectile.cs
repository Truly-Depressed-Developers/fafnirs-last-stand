using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 movement;
    private Vector3 rotation;

    private void Start()
    {
        if (gameObject.transform.position.x - PlayerPosition.Instance.transform.position.x < 0)
        {
            rotation = Vector3.back;
        }
        else
        {
            rotation = Vector3.forward;
        }
    }

    void Update()
    {
        gameObject.transform.Rotate(rotation, Space.Self);
        gameObject.transform.position += movement;
    }
}
