using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad = 5f;

    protected Rigidbody2D rb;
    private bool mirarDerecha = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
    }

    protected void Mover(Vector2 direccion)
    {
        rb.linearVelocity = direccion * velocidad;

        if ((mirarDerecha && direccion.x < 0) || (!mirarDerecha && direccion.x > 0))
        {
            mirarDerecha = !mirarDerecha;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }
}
