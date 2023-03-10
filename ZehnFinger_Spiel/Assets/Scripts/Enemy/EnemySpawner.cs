using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject floatingWord;
    // Moegliche weitere Enemys hier einfuegen

    [SerializeField]
    private GameObject spawnPoint;

    private float spawnIntervall = 3f;



    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = new Vector3(334, 218, 590);
        GameObject newEnemy = Instantiate(floatingWord, spawnPos, Quaternion.identity);
        StartCoroutine(spawnEnemy(spawnIntervall, enemyPrefab));
    }

    private IEnumerator  spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(spawnIntervall);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
