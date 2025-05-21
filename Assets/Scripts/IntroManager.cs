using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class IntroGameManager : MonoBehaviour
{
    [Header("Texto de introducción")]
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
            GameManager.instance.puedeMoverse = true;
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
            textoUI.text = ""; // limpiar texto anterior
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
    
    }

    void IniciarJuego()
    {
        textoTerminado = false;
        textoUI.gameObject.SetActive(false);

    // Buscar al jugador y reiniciar su flipX
        DonFauno player = FindFirstObjectByType<DonFauno>();
        if (player != null)
            {
            SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.flipX = true; // Empezar mirando a la derecha
            }
        }
        SceneManager.UnloadSceneAsync("IntroGame");
    }
}
