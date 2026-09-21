using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // ==============================
    // VARIABLES DEL CÓDIGO 01
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

        // Flip
        inputActions.Player.FlipR.started += _ => Flip();


        // Código 02
        lives = 3;
    }

    // ==============================
    // START
    // ==============================

    private void Start()
    {
        moveSpeed = 30f;
        desplSpeed = 5f;

        flipSpeed = 100f;

    }


    // ==============================
    // UPDATE
    // ==============================

    private void Update()
    {
     
        MovePlayer();


        // Rotación del personaje
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * rotation * 360f);
    }


    // ==============================
    // MOVIMIENTO
    // ==============================

    void MovePlayer()
    {
        // Movimiento horizontal
        if(CheckLimitsHorizontal())
        {
        transform.Translate(Vector3.right * desplSpeed * Time.deltaTime * moveX);

        }

        if (CheckLimitsVertical())
        {
            // Movimiento vertical
            transform.Translate(Vector3.up * desplSpeed * Time.deltaTime * moveY);
        }
    }


    // ==============================
    // COMPROBAR LÍMITES
    // ==============================

    bool CheckLimitsHorizontal()
    {
        float posX = transform.position.x;

        

        // Si estamos en el límite derecho
        // e intentamos seguir moviéndonos hacia la derecha
        if (posX >= limitsX && moveX > 0)
        {
            return false;
        }

        // Si estamos en el límite izquierdo
        // e intentamos seguir moviéndonos hacia la izquierda
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
    // FLIP
    // ==============================

    void Flip()
    {
        transform.Rotate(0f,0f,-360f * flipSpeed * Time.deltaTime);
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

