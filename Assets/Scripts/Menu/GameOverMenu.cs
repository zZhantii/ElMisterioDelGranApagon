using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public void Jugar()
    {
        StartCoroutine(ReiniciarJuego());
    }

    private IEnumerator ReiniciarJuego()
    {
        // Cargar MainLevel (reemplaza toda la escena actual)
        AsyncOperation mainLevel = SceneManager.LoadSceneAsync("MainLevel", LoadSceneMode.Single);
        while (!mainLevel.isDone)
        {
            yield return null;
        }

        // Cargar Map de forma aditiva
        AsyncOperation map = SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive);
        while (!map.isDone)
        {
            yield return null;
        }

        // Esperar un frame adicional para asegurar que GameManager se inicializó
        yield return null;

        if (GameManager.instance != null)
        {
            Debug.Log("✅ GameManager encontrado. Reiniciando juego.");
            GameManager.instance.ResetGame();
            GameManager.instance.IniciarJuego();
        }
        else
        {
            Debug.LogWarning("❌ GameManager no encontrado después de cargar escenas.");
        }
    }

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
