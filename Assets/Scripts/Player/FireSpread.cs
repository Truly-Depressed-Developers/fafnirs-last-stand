using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour {
    [SerializeField]
    private GameObject containerFlame;
    [SerializeField]
    private GameObject particle;


    private bool canSpawn = true;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            canSpawn = true;
            StartCoroutine(SpawnParticlesRoutine());
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            canSpawn = false;
        }
        /*if (Input.GetKey(KeyCode.Space))
        {
            if (transform.localScale.x < scaleLimit.x)
            {
                transform.localScale += fireScale;
            }
            
        } else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale -= fireScale;
            }
        }*/
    }

    IEnumerator SpawnParticlesRoutine() {
        while (canSpawn) {
            Debug.Log("Test");
            for (int i = 0; i < 3; i++) {
                GameObject particleObj = Instantiate(particle, transform.position, Quaternion.identity);
                particleObj.transform.parent = containerFlame.transform;
                float initialAngle = transform.rotation.eulerAngles.z + Random.Range(-10f, 10f);

                particleObj.transform.rotation = Quaternion.Euler(0, 0, initialAngle);
            }

            yield return new WaitForSeconds(0.1f);
        }
        yield return null;


    }


}
