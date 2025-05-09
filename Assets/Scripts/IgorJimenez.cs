using UnityEngine;

public class IgorJimenez : CharacterController
{
    public Transform target;

    protected override void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direccion = (target.position - transform.position).normalized;
        Mover(direccion);
    }
}
