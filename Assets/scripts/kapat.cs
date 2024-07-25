using UnityEngine;

public class kapat : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Oyun Editor'de çalýþýyorsa oyunu durdur
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Oyun derlenmiþ ise oyunu kapat
        Application.Quit();
#endif
    }
}
