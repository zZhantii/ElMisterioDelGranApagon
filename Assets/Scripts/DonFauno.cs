using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DonFauno : CharacterController
{
    public int vida = 1;
    public TextMeshProUGUI gameOverText;
    public AudioSource pasosAudioSource; 
    public AudioClip pasosClip;
    public Light2D luzJugador;

    protected override void Start()
    {
        base.Start(); 

        if (luzJugador == null)
        {
            luzJugador = GetComponent<Light2D>();
        }
    }

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
    protected override void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 direccion = new Vector2(h, v).normalized;

        Mover(direccion);

        bool estaMoviendose = direccion.magnitude > 0.1f;

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
            if (vida <= 0)
            {
                GameOver();
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

    public void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.enabled = true;
        }

        Time.timeScale = 0;
        Debug.Log("Game Over: DonFauno ha sido derrotado.");
    }
}
