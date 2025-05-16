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

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && estaVivo)
        {
            Debug.Log("¡Igor ha alcanzado al jugador!");

            DonFauno donFauno = col.gameObject.GetComponent<DonFauno>();
            if (donFauno != null)
            {
                donFauno.GameOver();
            }

          // Desactivar el objeto IgorJimenez
            estaVivo = false;
            rb.linearVelocity = Vector2.zero;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
