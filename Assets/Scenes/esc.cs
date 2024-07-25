using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçiþi için gerekli

public class esc : MonoBehaviour
{
    void Update()
    {
        // ESC tuþuna basýldýðýnda "Giris" sahnesine geçiþ yap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC tuþuna basýldý"); // Konsolda bilgi mesajý göster
            LoadGirisScene();
        }
    }

    void LoadGirisScene()
    {
        // "Giris" adlý sahneye geçiþ yap
        SceneManager.LoadScene("Giris");
    }
}
