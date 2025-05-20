using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BuloController : MonoBehaviour
{
    public static BuloController instance;

    public float delay1 = 0f;
    public float delay2 = 10f;
    public float delay3 = 20f;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void IniciarSecuenciaBulos()
    {
        StartCoroutine(GestionarBulos());
    }

    IEnumerator GestionarBulos()
    {
        yield return new WaitForSecondsRealtime(delay1);
        yield return MostrarEscenaBulo();

        yield return new WaitForSecondsRealtime(delay2 - delay1);
        yield return MostrarEscenaBulo();

        yield return new WaitForSecondsRealtime(delay3 - delay2);
        yield return MostrarEscenaBulo();
    }

    IEnumerator MostrarEscenaBulo()
    {
        AsyncOperation carga = SceneManager.LoadSceneAsync("EscenaBulo", LoadSceneMode.Additive);
        while (!carga.isDone)
            yield return null;

        while (SceneManager.GetSceneByName("EscenaBulo").isLoaded)
            yield return null;
    }
}
