using UnityEngine;

public class MusicaMenu : MonoBehaviour
{
 private static MusicaMenu instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
}
