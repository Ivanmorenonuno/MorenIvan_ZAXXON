using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    float interval = 0.05f;
    float maxpositionX = 20f;
    float maxpositionY = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        //StartCoroutine(SpawnEnemy());
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(interval);
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }
    void Update()
    {
       transform.position = new Vector3(Random.Range(-maxpositionX, maxpositionX), transform.position.y, transform.position.z);
       transform.position = new Vector3(transform.position.x, Random.Range(-maxpositionY, maxpositionY), transform.position.z);

    }
}
