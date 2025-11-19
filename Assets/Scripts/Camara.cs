using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;   // El jugador
    public float smoothSpeed = 5f;   // Qué tan suave sigue la cámara
    public Vector3 offset;     // Separación opcional

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPos;
    }
}
