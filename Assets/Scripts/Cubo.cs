using UnityEngine;
using UnityEngine.InputSystem;


public enum Speeds { Lento = 0, Normal = 1, Rapido = 2, MuyRapido = 3, Rapidisimo = 4}; // enum para darle determinadas velocidades
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public Speeds velocidad; // declaramos índice de velocidades

    //                                             0       1       2      3      4
    [SerializeField] float [] valoresVelocidad = { 8.6f, 10.4f, 12.96f, 15.6f, 19.27f};

    public Transform tocaSuelo;
    public float radioTocaSuelo;
    public LayerMask capaSuelo;

    Rigidbody2D rd;

    void Start()
    {
        //https://youtu.be/h0qwFV6cpOs?list=PLCmEmqCMwg-U77rz6O3ND-WQ1395f4NW1
        rd.linearVelocity = Vector2.zero;
        rd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position += Vector3.right * valoresVelocidad[(int)velocidad] * Time.deltaTime;

        if(Mouse.current.leftButton.isPressed)
        {
            if (OnGround())
            {
                rd.AddForce(Vector2.up * 26.6581f, ForceMode2D.Impulse);
            }
        }

        bool OnGround()
        {
            return Physics2D.OverlapCircle(tocaSuelo.position, radioTocaSuelo, capaSuelo );
        }
    }
    









  /* [SerializeField] public float moveSpeed = 7f;      // Velocidad hacia adelante
    [SerializeField] public float jumpHeight = 2f;     // Altura del salto sin físicas
    [SerializeField] public InputActionReference saltar;  // Acción de salto del Input System

    private bool isGrounded = true;
    private float baseY;

    void Start()
    {
        baseY = transform.position.y;

        saltar.action.performed += OnJump;
    }

    private void OnDestroy()
    {
        saltar.action.performed -= OnJump;
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (!isGrounded)
        {
            float newY = Mathf.MoveTowards(transform.position.y, baseY, 10f * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            if (Mathf.Abs(newY - baseY) < 0.01f)
            {
                transform.position = new Vector3(transform.position.x, baseY, transform.position.z);
                isGrounded = true;
            }
        }
    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (isGrounded)
        {
            transform.position = new Vector3(
                transform.position.x,
                transform.position.y + jumpHeight,
                transform.position.z
            );

            isGrounded = false;
        }
    }
  */
}

