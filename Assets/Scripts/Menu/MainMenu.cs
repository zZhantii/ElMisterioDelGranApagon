using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single); 
        SceneManager.LoadSceneAsync("Map", LoadSceneMode.Additive); 
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
