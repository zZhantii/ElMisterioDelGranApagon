using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class BulosIgorManager : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public string[] bulos;

    public float velocidadEscritura = 0.05f;
    public float tiempoParaLeer = 5f;  

    private RadioController radioController;

    private void Start()
    {
        radioController = FindObjectOfType<RadioController>();

        Time.timeScale = 0f;
        StartCoroutine(MostrarBulo());
    }

    IEnumerator MostrarBulo()
    {
        Time.timeScale = 0f;

        yield return EscribirBulo();

        yield return new WaitForSecondsRealtime(tiempoParaLeer);

        Time.timeScale = 1f;

        if (radioController != null)
        {
            radioController.OnBuloTerminado();
        }
        else
        {
            Debug.LogWarning("No se encontró RadioController para notificar el fin del bulo.");
        }

        SceneManager.UnloadSceneAsync("IgorBulos");
    }

    IEnumerator EscribirBulo()
    {
        textoUI.text = "";
        string bulo = bulos[Random.Range(0, bulos.Length)];
        foreach (char c in bulo)
        {
            textoUI.text += c;
            yield return new WaitForSecondsRealtime(velocidadEscritura);
        }
    }
}
