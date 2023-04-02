using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpread : MonoBehaviour {
    [SerializeField]
    private GameObject containerFlame;
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private float fireCooldown = 100f;
    private float fireCooldownTime = 35f;

    [SerializeField] RectTransform _firebarBackground;
    [SerializeField] RectTransform _firebarForeground;

    private bool canSpawn = true;

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            if (fireCooldown > 0) {
                fireCooldown -= fireCooldownTime * Time.deltaTime;
            } else {
                fireCooldown = 0;
            }
        } else {
            if (fireCooldown < 100) {
                fireCooldown += fireCooldownTime * 0.65f * Time.deltaTime;
            } else {
                fireCooldown = 100;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            canSpawn = true;
            StartCoroutine(SpawnParticlesRoutine());
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            canSpawn = false;
        }

        // Update FIREbar
        float maxWidth = _firebarBackground.sizeDelta.x;
        float percentage = fireCooldown / 100f;

        _firebarForeground.sizeDelta = new Vector2(maxWidth * percentage, _firebarForeground.sizeDelta.y);
    }

    IEnumerator SpawnParticlesRoutine() {
        while (canSpawn && fireCooldown > 0) {
            Debug.Log("Test");
            for (int i = 0; i < 3; i++) {
                GameObject particleObj = Instantiate(particle, transform.position, Quaternion.identity);
                particleObj.transform.parent = containerFlame.transform;
                float initialAngle = transform.rotation.eulerAngles.z + Random.Range(-10f, 10f);
                if (Input.GetKey(KeyCode.W)) {
                    particleObj.GetComponent<ParticleBehaviour>().isFaster = true;
                } else {
                    particleObj.GetComponent<ParticleBehaviour>().isFaster = false;
                }
                particleObj.transform.rotation = Quaternion.Euler(0, 0, initialAngle);
            }

            yield return new WaitForSeconds(0.1f);
        }
        yield return null;


    }


}
