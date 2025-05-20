using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DonFauno : CharacterController
{
    public int vida = 1;
    // public TextMeshProUGUI gameOverText;
    public Light2D luzJugador;

    public AudioSource pasosAudioSource;
    public AudioClip pasosClip;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private bool powerUpActivo = false;
    private float powerUpTimer = 0f;
    private float velocidadOriginal;
    public float velocidadAumentada = 10f;
    public void ActivarPowerUp(float duracion)
    {
        if (!powerUpActivo)
        {
            velocidadOriginal = velocidad;
            velocidad = velocidadAumentada;
        }

        powerUpActivo = true;
        powerUpTimer = duracion;

        Debug.Log("Power-Up de velocidad activado por " + duracion + " segundos.");
    }
    protected override void Start()
    {
        base.Start();

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (luzJugador == null)
        {
            luzJugador = GetComponent<Light2D>();
        }
        
    }

    void Awake()
    {
        // Reiniciar animator por si viene del menú u otra escena
        var animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.Rebind(); // Reinicia el Animator
            animator.Update(0); // Reinicia el estado actual
        }
    }

    protected override void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 direccion = new Vector2(h, v).normalized;

    if (GameManager.instance.puedeMoverse)
        {
        Mover(direccion);
        }
        


        bool estaMoviendose = direccion.magnitude > 0.1f;

        // Enviar valores al Animator
        animator.SetFloat("MoveX", h);
        animator.SetFloat("MoveY", v);

       

        // Sonido de pasos
        if (estaMoviendose)
        {
            if (!pasosAudioSource.isPlaying)
            {
                pasosAudioSource.clip = pasosClip;
                pasosAudioSource.loop = true;
                pasosAudioSource.Play();
            }
        }
        else
        {
            if (pasosAudioSource.isPlaying)
            {
                pasosAudioSource.Stop();
            }
        }

        // Control del Power-Up
        if (powerUpActivo)
        {
            powerUpTimer -= Time.deltaTime;
            if (powerUpTimer <= 0f)
            {
                powerUpActivo = false;
                velocidad = velocidadOriginal;
                Debug.Log("Power-Up de velocidad terminado.");
            }
        }
    }

    protected void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Enemigo"))
        {
            vida--;
            Debug.Log("DonFauno golpeado. Vida restante: " + vida);
            if (vida <= 0)
            {
                DerrotarDonFauno();
            }
        }
    }
    public void AumentarLuz(float cantidad)
    {
        if (luzJugador != null)
        {
            luzJugador.pointLightOuterRadius += cantidad;
        }
    }

    public void DerrotarDonFauno()
    {
        vida = 0;
        Debug.Log("DerrotarDonFauno llamado. Vida: " + vida);
        GameOver();
    }


    public void GameOver()
    {
        // if (gameOverText != null)
        // {
        //     gameOverText.enabled = true;
        //     Debug.Log("gameOverText habilitado.");
        // }
        // else
        // {
        //     Debug.LogError("gameOverText no está asignado.");
        // }

        Debug.Log("Game Over: DonFauno ha sido derrotado.");

        // Llamar al GameManager para terminar el juego
        if (GameManager.instance != null)
        {
            GameManager.instance.TerminarJuego();
            Debug.Log("GameManager.TerminarJuego() llamado.");
        }
        else
        {
            Debug.LogError("GameManager no está asignado.");
        }
    }
}
