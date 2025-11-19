using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 7f;      // Velocidad hacia adelante
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
}
