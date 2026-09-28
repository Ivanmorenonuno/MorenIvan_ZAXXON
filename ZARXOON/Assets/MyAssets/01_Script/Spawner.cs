using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;

    [Header("Movimiento del Spawner")]
    [SerializeField] float maxpositionX = 20f;
    [SerializeField] float maxpositionY = 10f;

    [Header("Spawn")]
    [SerializeField] float interval = 0.5f;

    [Header("Distancia")]
    [SerializeField] float distanciaInicial = -700f;
    [SerializeField] float distanciaEntreEnemigos = 50f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        float distanciaActual = distanciaInicial;

        while (true)
        {
            // Crear enemigo
            SacarEnemigo(distanciaActual);

            // Acercarnos progresivamente al spawner
            if (distanciaActual < 0f)
            {
                distanciaActual += distanciaEntreEnemigos;

                // Evitamos sobrepasar el spawner
                if (distanciaActual > 0f)
                {
                    distanciaActual = 0f;
                }
            }

            // Esperar hasta el siguiente enemigo
            yield return new WaitForSeconds(interval);
        }
    }

    void SacarEnemigo(float offsetZ)
    {
        float posX = Random.Range(-maxpositionX, maxpositionX);
        float posY = Random.Range(-maxpositionY, maxpositionY);

        Vector3 spawnPosition = new Vector3(
            posX,
            posY,
            transform.position.z + offsetZ
        );

        Instantiate(
            EnemyPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

    void Update()
    {
        transform.position = new Vector3(
            Random.Range(-maxpositionX, maxpositionX),
            Random.Range(-maxpositionY, maxpositionY),
            transform.position.z
        );
    }
}






