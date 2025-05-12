using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float duracion = 1.5f; 
  
  

   private void OnTriggerEnter2D(Collider2D collision)
    {

        
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El rayo ha impactado al jugador");

          
            DonFauno jugador = collision.GetComponent<DonFauno>();
            if (jugador != null)
            {
                jugador.ActivarPowerUp(duracion);
            }

          
            Destroy(gameObject);
        }
    }
}
