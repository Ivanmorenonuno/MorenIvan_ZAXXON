using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ==============================
    // VARIABLES DEL CODIGO 
    // ==============================

    public float moveSpeed;
    [SerializeField] float desplSpeed;

    // Input System
    MyInputActions inputActions;

    // Movimiento en XY
    float moveX;
    float moveY;

    // Velocidad de rotación
    float rotationSpeed = 0.5f;
    float rotation;

    //Rotacion suavizadad
    float maxRotation = 45f;
    [SerializeField] float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Vector3 currentRot;

    // Flip del personaje
    public float flipSpeed;

    // Contador de segundos
    float timeElapsed;


    // Variables serializadas
    [SerializeField] int ciclos = 10;
    [SerializeField] int lives = 3;

    // Límite de desplazamiento en X
    [SerializeField] float limitsX = 10f;

    // Límite de desplazamiento en Y
    [SerializeField] float limitsY = 5f;


    // ==============================
    // AWAKE
    // ==============================

    private void Awake()
    {
        // Creamos las acciones del Input System
        inputActions = new MyInputActions();

        // Disparo
        inputActions.Player.Fire.started += _ => Shoot();

        // Movimiento horizontal
        inputActions.Player.Movex.performed += ctx => moveX = ctx.ReadValue<float>();

        inputActions.Player.Movex.canceled += _ => moveX = 0f;

        // Movimiento vertical
        inputActions.Player.Movey.performed += ctx => moveY = ctx.ReadValue<float>();

        inputActions.Player.Movey.canceled += _ => moveY = 0f;

        // Rotación
        inputActions.Player.Rotar.performed += ctx => rotation = ctx.ReadValue<float>();

        inputActions.Player.Rotar.canceled += _ => rotation = 0f;

        // Limite de vidas
        lives = 3;

        // Velocidad de movimiento
        moveSpeed = 50f;
        desplSpeed = 10f;
    }

    // ==============================
    // START
    // ==============================

    private void Start()
    {
       
    }


    // ==============================
    // UPDATE
    // ==============================

    private void Update()
    {
     
        MovePlayer();


        // Rotación del personaje
        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotation * 360f);

        Vector3 vectorRotZ = Vector3.forward * -45f * moveX;
        Vector3 vectorRotX = Vector3.right * -20f * moveY;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref velocity, smoothTime);
        transform.eulerAngles = currentRot;
    }


    // ==============================
    // MOVIMIENTO
    // ==============================

    void MovePlayer()
    {
        // Movimiento horizontal
        if(CheckLimitsHorizontal())
        {
        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime * moveX,Space.World);
        }

        // Movimiento vertical
        if (CheckLimitsVertical())
        {
            transform.Translate(Vector3.up * desplSpeed * Time.deltaTime * moveY,Space.World);
        }
    }


    // ==============================
    // COMPROBAR LÍMITES
    // ==============================

    bool CheckLimitsHorizontal()
    {
        float posX = transform.position.x;

        

        // Si estamos en el límite horizontal
        if (posX >= limitsX && moveX > 0)
        {
            return false;
        }

        if (posX <= -limitsX && moveX < 0)
        {
            return false;
        }
        return true;
    }

    bool CheckLimitsVertical()
    {
        float posY = transform.position.y;
        // Si estamos en el límite superior
        if (posY >= limitsY && moveY > 0)
        {
            return false;
        }

        if (posY <= -limitsY && moveY < 0)
        {
            return false;
        }
        return true;
    }

    // ==============================
    // DISPARO
    // ==============================

    void Shoot()
    {
        print("POOOM");
    }

    // ==============================
    // INPUT SYSTEM
    // ==============================

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
}

