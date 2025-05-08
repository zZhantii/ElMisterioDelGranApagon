using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{public float velocidad;
    protected Rigidbody2D rb;

    protected bool mirarDerecha = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        // Este método se sobrescribirá en las subclases para implementar comportamientos específicos
    }

    protected void Movimiento(Vector2 direction)
    {
        rb.linearVelocity = direction * velocidad;
        Orientacion(direction.x);
    }

    protected void Orientacion(float inputMoviminetoHorizontal)
    {
        if ((mirarDerecha == true && inputMoviminetoHorizontal < 0) || (mirarDerecha == false && inputMoviminetoHorizontal > 0))
        {
            mirarDerecha = !mirarDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
