using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject igorJimenez;
    public Transform jugador;
    public Vector3 offset = new Vector3(0,100, 0);

    private GameManager gameManager;
    
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("No se encontró GameManager en la escena.");
        }
        else
        {
            Debug.Log("GameManager encontrado. Pilas restantes: " + gameManager.PilasRestantes);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameManager != null && gameManager.PilasTotales >= 4)
            {
                Debug.Log("Jugador cerca de la radio y tiene todas las pilas. Activando a Igor...");

                // Instanciar a Igor
                GameObject igorInstance = Instantiate(igorJimenez, jugador.position + offset, Quaternion.identity);

                // Asignar objetivo a Igor
                IgorJimenez aiScript = igorInstance.GetComponent<IgorJimenez>();
                if (aiScript != null)
                {
                    aiScript.jugador = jugador;
                }

                // Desactivar la radio
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("El jugador no tiene suficientes pilas para activar la radio.");
            }
        }
    }

}