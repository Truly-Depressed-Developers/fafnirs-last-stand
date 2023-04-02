using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] float _maxHp;
    float _currentHp;
    [SerializeField] int _pointsForKill;


    void Start() {
        if (_maxHp <= 0f) {
            Debug.LogError("Max HP needs to be positive!");
        }

        _currentHp = _maxHp;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerBullet") {
            Bullet bullet = collision.GetComponent<Bullet>();

            TakeDamage(bullet.damage);

            bullet.TryDestroy();
        }
    }
    private void TakeDamage(float damage = 999f) {
        _currentHp -= damage;

        if(_currentHp <= 0) {
            // add points
            ScoreManager.instance.AddScore(_pointsForKill);

            // die
            Spawner.Instance.spawnCount--;
            if (Spawner.Instance.enemiesKilled % 10 == 0)
            {
                Spawner.Instance.enemyCount++;
            }
            Destroy(this.gameObject);
        }
    }
}
