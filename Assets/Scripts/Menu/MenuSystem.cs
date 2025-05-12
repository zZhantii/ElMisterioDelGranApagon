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
            Debug.Log("PauseMenu cargado");
            menuCargado = true;
            enTransicion = false;

            ConfigurarBotonesPausa();
        };
    }

    private void ConfigurarBotonesPausa()
    {
        StartCoroutine(ConfigurarBotonesCoroutine());
    }

    private IEnumerator ConfigurarBotonesCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        Canvas[] todosLosCanvas = FindObjectsOfType<Canvas>(true);

        if (todosLosCanvas.Length == 0)
            Debug.LogWarning("No se encontraron Canvas al cargar PauseMenu.");

        foreach (Canvas canvas in todosLosCanvas)
        {
            Button[] botones = canvas.GetComponentsInChildren<Button>(true);

            foreach (Button boton in botones)
            {
                Debug.Log("Botón encontrado: " + boton.name);
                if (boton.name.Contains("Continuar") || boton.name.ToLower().Contains("continuar") ||
                    boton.name.Contains("Resume") || boton.name.ToLower().Contains("resume"))
                {

                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Continuar();
                    });

                    Debug.Log("Botón Continuar configurado correctamente");
                }
                else if (boton.name.Contains("Salir") || boton.name.ToLower().Contains("salir") ||
                         boton.name.Contains("Quit") || boton.name.ToLower().Contains("quit") ||
                         boton.name.Contains("Exit") || boton.name.ToLower().Contains("exit"))
                {

                    boton.onClick.RemoveAllListeners();

                    boton.onClick.AddListener(() =>
                    {
                        Salir();
                    });

                    Debug.Log("Botón Salir configurado correctamente");
                }
            }
        }
    }

     

public void Continuar()
    {
        if (!menuCargado || enTransicion) return;

        Debug.Log("Método Continuar invocado");
        enTransicion = true;

        Time.timeScale = 1f;
        juegoPausado = false;

        SceneManager.UnloadSceneAsync("PauseMenu").completed += (asyncOperation) =>
        {
            menuCargado = false;
            enTransicion = false;
            Debug.Log("Menú de pausa descargado correctamente");
        };
    }

    public void Salir()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();

    }
}