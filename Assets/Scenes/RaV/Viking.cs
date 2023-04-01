using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Viking : MonoBehaviour
{
    private float timer;

    public float attackSpeed;
    public GameObject Projectile;
    public Vector3 arrowTarget;
    public float arrowSpeed;
    public Vector3 vikingTarget;
    public float vikingSpeed;

    void Start()
    {
        Debug.Log("Spawned Viking");
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > attackSpeed)
        {
            timer -= attackSpeed;

            Debug.Log("Shot an arrow");

            // Pass parameters to the spawned child
            Vector3 outputArrow = arrowTarget.normalized * arrowSpeed;
            GameObject topFloorObj = Instantiate(Projectile, gameObject.transform.localPosition, Quaternion.identity);
            topFloorObj.GetComponent<Projectile>().movement = outputArrow;
        }
    }

    void Update()
    {
        // Make viking move
        Vector3 outputViking = vikingTarget.normalized * vikingSpeed;
        gameObject.transform.localPosition += outputViking;
    }
}
