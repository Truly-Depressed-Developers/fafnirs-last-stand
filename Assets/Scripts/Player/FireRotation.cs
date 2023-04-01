using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{
    [SerializeField]
    float firstAngle = -110;
    [SerializeField]
    float secondAngle = 110;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vector = new Vector2(cameraPos.x, cameraPos.y);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        float angle = Vector2.Angle(vector - pos, transform.up);
        transform.right = vector - pos;
        transform.RotateAround(transform.forward, -Mathf.PI / 2);
        Vector3 euler = transform.localRotation.eulerAngles;
        //Vector3 euler = transform.parent.eulerAngles - transform.eulerAngles;
        if (euler.z > 180) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, firstAngle, secondAngle);
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, euler.z);



    }


}
