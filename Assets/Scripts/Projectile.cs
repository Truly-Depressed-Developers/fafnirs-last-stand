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
    private float wae;

    private void Start()
    {
        if (gameObject.transform.position.x - PlayerPosition.Instance.transform.position.x < 0)
        {
            rotation = Vector3.back;
            wae = -1;
        }
        else
        {
            rotation = Vector3.forward;
            wae = 1;
        }
        Vector3 scale = gameObject.transform.localScale;
        gameObject.transform.localScale = new Vector3(scale.x, scale.y * wae, scale.z);
    }

    void Update()
    {
        gameObject.transform.Rotate(rotation, Space.Self);
        gameObject.transform.position += movement;
    }
}
