using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEditor.PlayerSettings;

public class Spawner : MonoBehaviour
{
    public int enemyCount;
    private int spawnCount;

    public float vikingAttackSpeed;
    public float vikingProjectileSpeed;
    public float vikingSpeed;

    [SerializeField]
    private GameObject Enemy;
    [SerializeField]
    private GameObject Bullets;

    void Update()
    {
        if (spawnCount < enemyCount)
        {
            GameObject viking = Instantiate(Enemy, DetermineSpawnPosition(), Quaternion.identity);
            viking.transform.SetParent(this.transform, false);
            viking.GetComponent<Viking>().Bullets = Bullets;
            viking.GetComponent<Viking>().attackSpeed = vikingAttackSpeed;
            viking.GetComponent<Viking>().projectileSpeed = vikingProjectileSpeed;
            spawnCount++;
        }
    }

    Vector3 DetermineSpawnPosition()
    {
        float angle = Random.Range(0, Mathf.PI * 2);
        Vector2 point = new();
        point.x = Mathf.Cos(angle) + .5f;
        point.y = Mathf.Sin(angle) + .5f;

        return Camera.main.ViewportToWorldPoint(new Vector3(point.x, point.y, 1));
    }
}
