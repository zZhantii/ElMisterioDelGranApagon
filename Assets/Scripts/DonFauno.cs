using UnityEngine;
using TMPro;

public class DonFauno : CharacterController
{
    public int vida = 1;
    public TextMeshProUGUI gameOverText;

    protected override void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 direccion = new Vector2(h, v).normalized;

        Mover(direccion);
    }

    protected void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Enemigo"))
        {
            vida--;
            if (vida <= 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.enabled = true;
        }

        Time.timeScale = 0; 
        Debug.Log("Game Over: DonFauno ha sido derrotado.");
    }
}
