using UnityEngine;

public class IgorJimenez : CharacterController
{
     public Transform jugador; 

    protected override void Start()
    {
        base.Start();
        GameObject faunoGO = GameObject.FindGameObjectWithTag("Player");

        if (faunoGO != null) {
            jugador = faunoGO.transform;
        } 
    }

    

    protected override void FixedUpdate()
    {
        if (jugador != null)
        {
            Vector2 direccion = (Vector2)(jugador.position - transform.position);
            Mover(direccion.normalized);
        }
    }

    private bool estaVivo = true;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DonFauno donFauno = collision.gameObject.GetComponent<DonFauno>();
            if (donFauno != null)
            {
                donFauno.DerrotarDonFauno();
                Debug.Log("IgorJimenez golpeó a DonFauno.");
            }
            else
            {
                Debug.LogError("DonFauno no está asignado en la colisión.");
            }
        }
        else
        {
            Debug.Log("Colisión detectada, pero no es con el jugador.");
        }
    }
}
