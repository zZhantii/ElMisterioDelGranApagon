using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject MusicaPrincipal;
    public void IrAIntro()
    {
        MusicaMenu musica = FindFirstObjectByType<MusicaMenu>();


        if (musica != null)
        {
            Destroy(musica.gameObject);
        }
        SceneManager.LoadScene("IntroGame");
    }

    public void MostrarAyuda()
    {
        SceneManager.LoadScene("Help");
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
