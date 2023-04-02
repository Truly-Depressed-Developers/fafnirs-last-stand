using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _particleSpeed = 5f;
    [SerializeField]
    private float _destoyTime = 1f;
    [SerializeField]
    private GameObject playerMovement;
    
    private float initialAngle;
    Vector3 fireScale;
    Vector3 scaleLimit;
    private float startTime;
    public bool isFaster;
    // Start is called before the first frame update
    void Start()
    {
        /*        initialAngle = transform.rotation.z + Random.Range(-10f, 10f);*/
        transform.localScale = fireScale;
        fireScale = new Vector3(1f, 1f, 1f);
        scaleLimit = new Vector3(1f, 1f, 1f);
        startTime = Time.time;
        Destroy(gameObject, _destoyTime);
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.position = new Vector3(0, transform.position.y + 1f * Time.deltaTime,0);*/
        /*transform.rotation = Quaternion.Euler(0, 0, initialAngle);*/

        if (isFaster)
        {
            transform.position = transform.position + transform.up * _particleSpeed * Time.deltaTime * 1.55f;
        } else
        {
            transform.position = transform.position + transform.up * _particleSpeed * Time.deltaTime;
        }
        
        Debug.Log((Time.time - startTime) / _destoyTime);

        float scale = Mathf.Lerp(0.05f, 1f, (Time.time - startTime) / _destoyTime);
        transform.localScale = new Vector3(scale, scale, 1);
        /*if (transform.localScale.x < scaleLimit.x)
        {
            transform.localScale += fireScale * Time.deltaTime;
        }*/
        
        /*StartCoroutine(destroyRoutine());*/
    }



    /*IEnumerator destroyRoutine()
    {
        yield return new WaitForSeconds(5f);
        this.transform.
    }*/
}
