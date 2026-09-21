using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform PlayerTransform;

    [SerializeField] float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    // Desplazamiento

    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetY=1f;
        offsetZ=-10f;

        RotateCamera();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 offset=new Vector3(0,offsetY,offsetZ);  

        transform.position=PlayerTransform.position + offset;


       
    }

    bool RotateCamera()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        if (posX < -10f || posX > 10f)
        {
            return false;
        }
        if (posY < -5f || posY > 5f)
        {
            return false;
        }
        return true;
    }
}
