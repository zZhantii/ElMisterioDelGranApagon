using UnityEngine;

public class Pila : MonoBehaviour
{
    public int valor = 1;
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.sumarPilas(valor);
            Destroy(this.gameObject);
        }
    }
}
