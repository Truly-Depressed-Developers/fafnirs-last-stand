using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRotation : MonoBehaviour
{
    [SerializeField]
    float firstAngle = -110;
    [SerializeField]
    float secondAngle = 110;

    float prevAngle = 0;

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
        float angle = Vector2.SignedAngle(vector - pos, transform.parent.up);
        float dif = angle - prevAngle;
        float newAngle = prevAngle + dif * 5f * Time.deltaTime;
        newAngle = Mathf.Clamp(newAngle, firstAngle, secondAngle);
        prevAngle = newAngle;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, -newAngle);


    }


}
