using UnityEngine;

public class IgorJimenez : CharacterController
{
     public Transform jugador; // Asignar desde el editor o desde RadioInteract.cs


    protected override void Start()
    {
        base.Start(); // Llama al Start() de CharacterController
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
