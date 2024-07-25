using UnityEngine;
using UnityEngine.SceneManagement; // Sahne geçiþi için gerekli

public class basla : MonoBehaviour
{
    public void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // Bir sonraki sahneye geçiþ

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Son sahneyi geçmeye çalýþmýyorsanýz
        {
            SceneManager.LoadScene(nextSceneIndex); // Bir sonraki sahneyi yükle
        }
        else
        {
            Debug.LogWarning("No next scene available."); // Eðer geçiþ yapýlacak sahne yoksa uyarý ver
        }
    }
}
