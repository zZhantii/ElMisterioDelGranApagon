using UnityEngine;

public class Gate : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       Debug.Log("Colisión detectada con: " + collision.gameObject.name);
       
       if (collision.CompareTag("Player"))
       {
           
           DonFauno jugador = collision.GetComponent<DonFauno>();
           IgorJimenez igor = FindFirstObjectByType<IgorJimenez>();
           if (jugador != null && igor != null)
            {
                Debug.Log("Componente DonFauno encontrado");
                GameManager.instance.TerminarJuego(true);

            }
            else
            {
                Debug.LogError("No se encontró el componente DonFauno");
            }

         
       }
     
   }
}
