using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RadioController : MonoBehaviour
{
    public GameObject igorJimenez;
    public Transform jugador;
    public GameObject rayo;
    public Vector3 offset = new Vector3(0, 1, 0);

    private bool buloActivo = false;

    void Start()
    {
        GameObject IgorGO = GameObject.FindGameObjectWithTag("Enemigo");

        if (IgorGO != null)
        {
            jugador = IgorGO.transform;
        }
    }

    private void ActivarRayo()
    {
        if (rayo != null)
        {
            Debug.Log("Rayo activado");
            rayo.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !buloActivo)
        {
            if (GameManager.instance != null && GameManager.instance.PilasTotales >= 4)
            {
                Debug.Log("Jugador cerca de la radio y tiene todas las pilas. Activando a Igor...");

                gameObject.SetActive(false);

                // Instanciar a Igor
                GameObject igorInstance = Instantiate(igorJimenez, jugador.position + offset, Quaternion.identity);

                // Asignar objetivo a Igor
                IgorJimenez aiScript = igorInstance.GetComponent<IgorJimenez>();
                if (aiScript != null)
                {
                    aiScript.jugador = jugador;
                    ActivarRayo();
                }

                buloActivo = true;
                // StartCoroutine(EsperarYCargarBulo());
            }
            else
            {
                Debug.Log("El jugador no tiene suficientes pilas para activar la radio.");
            }
        }
    }

    IEnumerator EsperarYCargarBulo()
    {
        yield return new WaitForSecondsRealtime(4f);
        Debug.Log("Cargando bulos escena");
        SceneManager.LoadScene("IgorBulos", LoadSceneMode.Additive);
    }

    public void OnBuloTerminado()
    {
        Debug.Log("RadioController recibió notificación: bulo terminado.");
        StartCoroutine(VolverACargarBulo());
    }

    IEnumerator VolverACargarBulo()
    {
        yield return new WaitForSecondsRealtime(2f);

        Debug.Log("Recargando escena del bulo para mostrar otro...");
        SceneManager.LoadScene("IgorBulos", LoadSceneMode.Additive);
    }
}
