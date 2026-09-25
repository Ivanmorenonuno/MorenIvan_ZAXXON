using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed;
    float MySpeed = 0.5f;

    [SerializeField] PlayerManager Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Player.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Player.moveSpeed+ MySpeed;
        transform.Translate(Vector3.back * Time.deltaTime * speed); 
    }
}
