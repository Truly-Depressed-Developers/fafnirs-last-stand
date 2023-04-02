using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] float _maxHp;
    [SerializeField] float _currentHp;
    [SerializeField] RectTransform _healthbarBackground;
    [SerializeField] RectTransform _healthbarForeground;

    public static event Action OnPlayerDeath;

    void Start() {
        if (_maxHp == 0) {
            Debug.LogError("Max HP can't be 0!");
        }

        _currentHp = _maxHp;

        AdjustHealthbar();

        OnPlayerDeath += PlayerDeath;
    }

    public void TakeDamage(float damage) {
        _currentHp -= damage;

        AdjustHealthbar();

        if (_currentHp <= 0) {
            // die

            PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "EnemyBullet") {
            Bullet bullet = collision.GetComponent<Bullet>();

            TakeDamage(bullet.damage);
            Destroy(collision.gameObject);
        }
    }

    private void AdjustHealthbar() {
        float maxWidth = _healthbarBackground.sizeDelta.x;
        float HPPercentage = _currentHp / _maxHp;

        _healthbarForeground.sizeDelta = new Vector2(maxWidth * HPPercentage, _healthbarForeground.sizeDelta.y);
    }

    private void PlayerDeath() {
        // die

        OnPlayerDeath();
        Destroy(this.gameObject);
    }
}
