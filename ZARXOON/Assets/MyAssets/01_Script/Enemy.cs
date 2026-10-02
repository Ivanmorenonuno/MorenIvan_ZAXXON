using UnityEngine;

public class Enemy02 : MonoBehaviour
{
    float speed;
    float MySpeed = 50f;

    [SerializeField] PlayerManager Player;

    [SerializeField] float distanciaDesaparicion = -20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtener referencia al PlayerManager
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        Player = playerGO.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover el enemigo hacia atrás en el eje Z
        speed = Player.moveSpeed+ MySpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        // Destruir el enemigo si se encuentra más allá de la distancia de desaparición
        if (transform.position.z < distanciaDesaparicion)
        {
            Destroy(gameObject);
        }

    }
}
