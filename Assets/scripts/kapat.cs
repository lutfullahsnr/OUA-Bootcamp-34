using UnityEngine;

public class kapat : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Oyun Editor'de çalışıyorsa oyunu durdur
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Oyun derlenmiş ise oyunu kapat
        Application.Quit();
#endif
    }
}
