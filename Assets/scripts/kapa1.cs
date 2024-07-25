using UnityEngine;
using TMPro;

public class kapa1 : MonoBehaviour
{
    public TMP_Text displayText; // Ekranda gösterilecek metin için referans

    void Start()
    {
        // Baþlangýçta TMP Text objesini göster
        displayText.gameObject.SetActive(true);

        // 10 saniye sonra TMP Text objesini gizle
        StartCoroutine(HideTextAfterDelay(10f));
    }

    System.Collections.IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        displayText.gameObject.SetActive(false); // TMP objesini gizle
    }
}