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
    // Start is called before the first frame update
    void Start()
    {
        playerController = transform.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.forward * Time.deltaTime * _speed;
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * 40f * -Time.deltaTime * 5);
        float velocity = 0;
        velocity = velocity + _speed * Time.deltaTime;
        if (velocity > _maxspeed)
        {
            velocity = _maxspeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * velocity;

        }

    }
}
