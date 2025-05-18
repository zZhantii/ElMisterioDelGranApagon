using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public void IrAIntro()
    {
        
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
