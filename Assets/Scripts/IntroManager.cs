using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class IntroGameManager : MonoBehaviour
{
    public TextMeshProUGUI textoUI;
    public string[] frases;
    public float velocidadEscritura = 0.01f;
    public float tiempoEntreFrases = 1f;

    private bool textoTerminado = false;

    void Start()
    {
        
        StartCoroutine(CargarEscenasJuego());
    }

    void Update()
    {
        if (textoTerminado && Input.GetMouseButtonDown(0))
        {
            IniciarJuego();
        }
    }

    IEnumerator CargarEscenasJuego()
    {
        AsyncOperation mainLevel = SceneManager.LoadSceneAsync("MainLevel", LoadSceneMode.Additive);
        AsyncOperation map = SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive);

        while (!mainLevel.isDone || !map.isDone)
        {
            yield return null;
        }

        yield return null;

        Scene scene = SceneManager.GetSceneByName("MainLevel");
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            if (go.name == "GameContent")
            {
                go.SetActive(false);
            }
        }

        StartCoroutine(MostrarTexto());
    }

    IEnumerator MostrarTexto()
    {
          yield return new WaitForEndOfFrame(); 
   
        textoUI.text = "";

        foreach (string frase in frases)
        {
            textoUI.text = "";
            foreach (char letra in frase)
            {
                textoUI.text += letra;
                yield return new WaitForSeconds(velocidadEscritura);
            }

            yield return new WaitForSeconds(tiempoEntreFrases);
        }

        textoUI.text = "<i>Haz clic para comenzar...</i>";
        textoTerminado = true;
        Time.timeScale = 1f;
        GameManager.instance.puedeMoverse = true;
    
    }

    void IniciarJuego()
    {
        Scene scene = SceneManager.GetSceneByName("MainLevel");
        foreach (GameObject go in scene.GetRootGameObjects())
        {
            if (go.name == "GameContent")
            {
                go.SetActive(true);
            }
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.ResetGame();
            GameManager.instance.IniciarJuego();
        }

        SceneManager.UnloadSceneAsync("IntroGame");
    }
}
