using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;

public class FaunoLadriez : CharacterController{
    public int vida = 1;
    public TextMeshProUGUI gameOverText;
     protected override void Update()
    {
        float inputMoviminetoHorizontal = Input.GetAxis("Horizontal");
        float inputMoviminetoVertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(inputMoviminetoHorizontal, inputMoviminetoVertical);
        Movimiento(direction);
    }

    protected void OnCollisionEnter2D(Collision2D colision)
    {
        if(colision.gameObject.tag == "Enemigo")
        {
            vida --;
            if(vida == 0)
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }
}