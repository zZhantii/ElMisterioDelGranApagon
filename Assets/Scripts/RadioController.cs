using UnityEngine;

public class RadioController : MonoBehaviour
{
    public GameObject igorJimenez;
    public Transform jugador;
    public Vector3 offset = new Vector3(0,100, 0);

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Jugador cerca de la radio");

            GameObject igorInstance = Instantiate(igorJimenez, jugador.position + offset, Quaternion.identity);
            

            IgorJimenez aiScript = igorInstance.GetComponent<IgorJimenez>();
            if (aiScript != null)
            {
                aiScript.jugador = jugador;
            }

            gameObject.SetActive(false);
        }
    }

}