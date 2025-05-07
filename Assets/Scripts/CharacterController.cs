using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    private Rigidbody2D rb;

    private bool mirarDerecha = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    void Update()
    {
        Movimiento();
    }

    void Movimiento () 
    {
        float inputMoviminetoHorizontal = Input.GetAxis("Horizontal"); 
        float inputMoviminetoVertical = Input.GetAxis("Vertical"); 

        rb.linearVelocity = new Vector2(inputMoviminetoHorizontal * velocidad, inputMoviminetoVertical * velocidad);

        orientacion(inputMoviminetoHorizontal);
    }

    void orientacion(float inputMoviminetoHorizontal)
    {
        if ((mirarDerecha == true && inputMoviminetoHorizontal < 0) || (mirarDerecha == false && inputMoviminetoHorizontal > 0))
        {
           mirarDerecha = !mirarDerecha;
           transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
