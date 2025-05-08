using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class IgorJimenez : CharacterController{
    public Transform target; 

    protected override void Update()
    {
        PerseguirJugador();
    }

    private void PerseguirJugador()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            Movimiento(direction);
        }
    }
}