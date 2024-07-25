using UnityEngine;
using UnityEngine.SceneManagement; // Sahne ge�i�i i�in gerekli

public class basla : MonoBehaviour
{
    public void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1; // Bir sonraki sahneye ge�i�

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings) // Son sahneyi ge�meye �al��m�yorsan�z
        {
            SceneManager.LoadScene(nextSceneIndex); // Bir sonraki sahneyi y�kle
        }
        else
        {
            Debug.LogWarning("No next scene available."); // E�er ge�i� yap�lacak sahne yoksa uyar� ver
        }
    }
}
