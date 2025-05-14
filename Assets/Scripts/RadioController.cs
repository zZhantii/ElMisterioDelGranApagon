using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject igorJimenez;
    public Transform jugador;
    public Vector3 offset = new Vector3(0,1, 0);
    
    void Start()
    {
        GameObject IgorGO = GameObject.FindGameObjectWithTag("Enemigo");

        if (IgorGO != null)
        {
            jugador = IgorGO.transform;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.instance != null && GameManager.instance.PilasTotales >= 4)
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