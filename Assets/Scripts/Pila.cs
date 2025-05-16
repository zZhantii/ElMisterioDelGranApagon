using UnityEngine;

public class Pila : MonoBehaviour
{
    public int valor = 1;
    public float cantidadAumentoLuz = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.sumarPilas(valor);

            DonFauno donFauno = collision.GetComponent<DonFauno>();
            if (donFauno != null)
            {
                donFauno.AumentarLuz(cantidadAumentoLuz);
            }

            Destroy(gameObject);
        }
    }
}
