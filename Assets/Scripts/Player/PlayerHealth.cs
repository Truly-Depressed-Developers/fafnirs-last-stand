using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] float _maxHp;
    float _currentHp;

    public static event Action OnPlayerDeath;

    void Start() {
        if(_maxHp == 0) {
            Debug.LogError("Max HP can't be 0!");
        }

        _currentHp = _maxHp;
    }

    public void TakeDamage(float damage) {
        _currentHp -= damage;

        if(_currentHp <= 0) {
            // die

            OnPlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Bullet") {
            Bullet bullet = collision.GetComponent<Bullet>();

            TakeDamage(bullet.damage);
        }
    }
}
