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
}
