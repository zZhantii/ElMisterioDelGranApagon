using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int PilasTotales { get { return pilasTotales; } }
    private int pilasRestantes = 4;
    public int PilasRestantes { get { return pilasRestantes; } }
    private int pilasTotales;

    float tiempoLimite = 120f;
    float tiempoRestante;
    public float TiempoRestante { get { return tiempoRestante; } }
    private bool juegoTerminado = false;

    private bool partidaIniciada = false;
    public bool PartidaIniciada => partidaIniciada;

    public bool puedeMoverse = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        tiempoRestante = tiempoLimite;
        partidaIniciada = false;
        juegoTerminado = false;
    }

    public void congelarTiempo(float tiempo)
    {
        tiempoRestante = tiempo;
    }

    void Update()
    {
        // Debug.Log($"Update - partidaIniciada: {partidaIniciada}, juegoTerminado: {juegoTerminado}, tiempoRestante: {tiempoRestante}");

        if (!partidaIniciada || juegoTerminado)
            return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            TerminarJuego();
        }
    }

    public void sumarPilas(int pilasSumar)
    {
        pilasTotales += pilasSumar;
    }

    

    public void ResetGame()
    {
        tiempoRestante = tiempoLimite;
        pilasTotales = 0;
        juegoTerminado = false;
    }

    public void IniciarJuego()
    {
        partidaIniciada = true;
    }

    public void IniciarJuego2()
    {
        partidaIniciada = true;
        puedeMoverse = true;
    }


    public void TerminarJuego(bool win = false)
    {

        if (win)
        {
            Debug.Log("¡Victoria! Has ganado el juego.");
            SceneManager.LoadScene("WinMenu");
        }
        else
        {
            Debug.Log("¡Derrota! Has perdido el juego.");

            // Mostrar menú GameOver (activo el canvas o escena)
            SceneManager.LoadScene("GameOver");
        }
        juegoTerminado = true;
        partidaIniciada = false;
        // BuloManager.instance.ResetBulos();

    }





}