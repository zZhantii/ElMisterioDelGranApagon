using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float duracion = 5.0f; 
  
  

 
private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Colisión detectada con: " + collision.gameObject.name);
    
    if (collision.CompareTag("Player"))
    {
        Debug.Log("Es el jugador");
          
        DonFauno jugador = collision.GetComponent<DonFauno>();
        if (jugador != null)
        {
            Debug.Log("Componente DonFauno encontrado");
            jugador.ActivarPowerUp(duracion);
        }
        else
        {
            Debug.LogError("No se encontró el componente DonFauno");
        }

        Destroy(gameObject);
    }
    else
    {
        Debug.Log("No es el jugador, tag: " + collision.tag);
    }
}
}