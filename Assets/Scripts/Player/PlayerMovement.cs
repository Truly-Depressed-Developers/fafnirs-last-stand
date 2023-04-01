using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _maxspeed = 200f;

    void Update()
    {
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 40f * -Time.deltaTime * 5);
        float velocity = 0;
        if (Input.GetKey(KeyCode.W))
            velocity += _speed * Time.deltaTime;
        else
            velocity -= _speed * Time.deltaTime;

        if (velocity > _maxspeed)
        {
            velocity = _maxspeed;
        } else if (velocity < 0)
        {
            velocity = 0;
        }
            

        transform.position += transform.up * velocity;


    }
}