using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TouchMessage : MonoBehaviour
{
    public TextMeshProUGUI touchText;
    public string message;
    public float duration = 3f;
    public float typingSpeed = 0.05f;
    private bool isTouching = false;
    int pilas = GameManager.instance.PilasTotales;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTouching)
        {
            if (pilas < 4)
            {
                touchText.text = message;
                isTouching = true;
                StartCoroutine(ShowMessage());
            }
        }
    }

    private System.Collections.IEnumerator ShowMessage()
    {
        touchText.gameObject.SetActive(true);
        touchText.text = "";

        string fullMessage = message;

        for (int i = 0; i < fullMessage.Length; i++)
        {
            touchText.text += fullMessage[i];
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(duration);
        touchText.gameObject.SetActive(false);
        isTouching = false;
    }
}
