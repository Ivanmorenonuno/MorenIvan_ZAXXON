using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;

    // Desplazamiento

    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetY=1f;
        offsetZ=-10f;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 offset=new Vector3(0,offsetY,offsetZ);  

        transform.position=PlayerTransform.position + offset;

    }
}
