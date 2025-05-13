using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MenuSystem : MonoBehaviour
{
    private bool juegoPausado = false;
    private bool menuCargado = false;
    private bool enTransicion = false;

    public static MenuSystem Instance { get; private set; }

    // Singleton para asegurarme que solo haya una instancia del script
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !enTransicion)
        {
            if (juegoPausado)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        if (menuCargado || enTransicion) return;

        enTransicion = true;

        Time.timeScale = 0f;
        juegoPausado = true;

        SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive).completed += (asyncOperation) =>
        {
            // Debug.Log("PauseMenu cargado");
            menuCargado = true;
            enTransicion = false;

            ConfigurarBotonesPausa();
        };
    }

    // Metodo para la configuracion de los botones del menu de pausa
    private void ConfigurarBotonesPausa()
    {
        StartCoroutine(ConfigurarBotonesCoroutine());
    }

    // Coroutine con tiempo de espera para que termine de cargar el menu
    private IEnumerator ConfigurarBotonesCoroutine()
    {
        // Tiempo de espera
        yield return new WaitForSecondsRealtime(0.1f);

        // Recoge todos los Canvas de la escena
        Canvas[] todosLosCanvas = FindObjectsOfType<Canvas>(true);

        if (todosLosCanvas.Length == 0)
        {
            Debug.LogWarning("No se encontró ningún Canvas en la escena PauseMenu.");
            // Termina el coroutine 
            yield break;
        }

        foreach (Canvas canvas in todosLosCanvas)
        {
            Button[] botones = canvas.GetComponentsInChildren<Button>(true);

            foreach (Button boton in botones)
            {
                if (boton.name.Contains("Continuar"))
                {
                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Continuar();
                    });
                }
                else if (boton.name.Contains("Salir"))
                {
                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Salir();
                    });
                }
            }

        }
    }

    public void Continuar()
    {
        if (!menuCargado || enTransicion) return;

        enTransicion = true;

        Time.timeScale = 1f;
        juegoPausado = false;

        SceneManager.UnloadSceneAsync("PauseMenu").completed += (asyncOperation) =>
        {
            menuCargado = false;
            enTransicion = false;
            // Debug.Log("Menú de pausa descargado correctamente");
        };
    }

    public void Salir()
    {
        Application.Quit();
        // Cierra el editor
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}