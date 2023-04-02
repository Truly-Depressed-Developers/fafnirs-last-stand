using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float damage;
    public bool shouldDeleteAfterCollision = false;

    public void TryDestroy() {
        if(shouldDeleteAfterCollision) {
            Destroy(this.gameObject);
        }
    }
}