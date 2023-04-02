using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Viking : MonoBehaviour
{
    // Attack speed
    private float timerAS;
    public float attackSpeed;
    // Movement speed
    private float timerMS;
    public float moveInterval;

    public GameObject Projectile;
    public Vector3 arrowTarget;
    public float projectileSpeed;

    [SerializeField]
    private float stopDistance;

    public GameObject BulletsContainer;

    void Start()
    {
        Debug.Log("Spawned Viking");
    }

    void Update()
    {
        // Attack speed
        timerAS += Time.deltaTime;
        if (timerAS > attackSpeed)
        {
            timerAS -= attackSpeed;
            arrowTarget = PlayerPosition.Instance.transform.position - transform.position;
            arrowTarget.z = 0f;
            Vector3 outputArrow = arrowTarget.normalized * projectileSpeed;
            GameObject projectile = Instantiate(Projectile, transform.position, Quaternion.identity, BulletsContainer.transform);
            projectile.GetComponent<Projectile>().movement = outputArrow;
        }

        // Movement speed
        timerMS += Time.deltaTime;
        if (timerMS > moveInterval)
        {
            timerMS -= moveInterval;

            if (Vector3.Distance(transform.position, PlayerPosition.Instance.transform.position) > 5) 
            {
                transform.position = Vector3.MoveTowards(
                    new Vector3(transform.position.x, transform.position.y, 0),
                    new Vector3(PlayerPosition.Instance.transform.position.x, PlayerPosition.Instance.transform.position.y, 0), .005f);
                    //obrys dla siekierki i smoczka skoczka
                    //niszczenie siekierkuf po jakim? czasie
            }
        }
    }
}
