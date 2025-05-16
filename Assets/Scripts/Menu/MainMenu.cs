using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        StartCoroutine(CargarJuego());
    }

    private IEnumerator CargarJuego()
    {
        AsyncOperation mainLevel = SceneManager.LoadSceneAsync("MainLevel", LoadSceneMode.Single);
        AsyncOperation map = SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive);

        GameManager.instance.IniciarJuego();

        while (!mainLevel.isDone || !map.isDone)
        {
            yield return null;
        }

        if (GameManager.instance != null)
        {
            GameManager.instance.IniciarJuego();
        }
    }


    public void MostrarAyuda()
    {
        Debug.Log("Mostrar ayuda...");
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Cierra el editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
        #endif
    }
}
