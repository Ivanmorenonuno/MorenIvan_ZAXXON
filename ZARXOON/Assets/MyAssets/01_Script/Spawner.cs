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
    [SerializeField] float distanciaInicial = -600f;
    [SerializeField] float distanciaEntreEnemigos = 10f;

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

            // Si todavía no hemos llegado a 0,
            // acercamos el siguiente enemigo
            if (distanciaActual < 0)
            {
                distanciaActual -= distanciaEntreEnemigos;

                // Evitamos que se pase de 0
                if (distanciaActual > 0)
                {
                    distanciaActual = 0;
                }
            }

            // Esperar hasta el siguiente spawn
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





