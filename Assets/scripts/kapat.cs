using UnityEngine;

public class kapat : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        // Oyun Editor'de �al���yorsa oyunu durdur
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Oyun derlenmi� ise oyunu kapat
        Application.Quit();
#endif
    }
}
