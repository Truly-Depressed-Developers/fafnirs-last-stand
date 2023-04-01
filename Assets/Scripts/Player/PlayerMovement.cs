using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 200f;
    private Rigidbody2D body;
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 40f * -Time.deltaTime * 5);
        float forward = Input.GetAxis("Vertical");
        if (forward < 0)
        {
            forward = 0;
        }
        body.velocity = transform.up * forward * _speed * Time.fixedDeltaTime * 50f;

    }
}