using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FaunoLadriez : CharacterController{
     protected override void Update()
    {
        float inputMoviminetoHorizontal = Input.GetAxis("Horizontal");
        float inputMoviminetoVertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(inputMoviminetoHorizontal, inputMoviminetoVertical);
        Movimiento(direction);
    }
}