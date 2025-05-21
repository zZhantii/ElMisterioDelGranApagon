using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class BuloSceneManager : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public string[] bulos;
    public float velocidadLetra = 0.05f;
    public float tiempoVisible = 3f;

    void Start()
    {
        StartCoroutine(ShowBulo());
    }

    IEnumerator ShowBulo()
    {
        Time.timeScale = 0f;

        string bulo = bulos[Random.Range(0, bulos.Length)];
        textoUI.text = "";

        foreach (char letra in bulo)
        {
            textoUI.text += letra;
            yield return new WaitForSecondsRealtime(velocidadLetra);
        }

        yield return new WaitForSecondsRealtime(tiempoVisible);

        textoUI.text = "";
        Time.timeScale = 1f;

        SceneManager.UnloadSceneAsync("EscenaBulo");
    }
}
