using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    float MySpeed = 50f;

    [SerializeField] PlayerManager Player;

    [SerializeField] float distanciaDesaparicion = -1200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        Player = playerGO.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = Player.moveSpeed+ MySpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed); 

        if (transform.position.z < distanciaDesaparicion)
        {
            Destroy(gameObject);
        }

    }
}
