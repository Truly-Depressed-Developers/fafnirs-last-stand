using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _maxspeed = 200f;
    CharacterController playerController;

    [SerializeField]
    Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        playerController = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 move = transform.forward * Time.deltaTime * _speed;

        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 40f * -Time.deltaTime * 5);
        float velocity = 0;
        velocity = velocity + _speed * Time.deltaTime;
        if (velocity > _maxspeed)
        {
            velocity = _maxspeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += transform.up * velocity;
            Vector3 localVelocity = Vector3.ClampMagnitude(new Vector3(0, velocity, 0), 1) * _speed;

            _rb2d.velocity = transform.TransformDirection(localVelocity) * _speed;

        } else
        {
            _rb2d.velocity = new Vector2(0, 0);

        }

    }
}
