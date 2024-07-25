using UnityEngine;
using UnityEngine.SceneManagement; // Sahne ge�i�i i�in gerekli

public class esc : MonoBehaviour
{
    void Update()
    {
        // ESC tu�una bas�ld���nda "Giris" sahnesine ge�i� yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC tu�una bas�ld�"); // Konsolda bilgi mesaj� g�ster
            LoadGirisScene();
        }
    }

    void LoadGirisScene()
    {
        // "Giris" adl� sahneye ge�i� yap
        SceneManager.LoadScene("Giris");
    }
}
