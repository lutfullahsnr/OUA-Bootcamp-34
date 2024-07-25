using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Sahne ge�i�i i�in gerekli

public class ata5 : MonoBehaviour
{
    public TMP_Text displayText; // Ekranda g�sterilecek metin i�in referans
    private string targetWord = "G�zlerini A�"; // Hedef kelime
    private string typedWord = ""; // Oyuncunun yazd��� kelime
    private bool isRestarting = false; // Yeniden ba�lama durumu

    void Start()
    {
        // Ba�lang��ta hedef kelimeyi beyaz olarak ekrana yazd�r
        UpdateDisplayText();
    }

    void Update()
    {
        // Yeniden ba�lama s�recindeyken ba�ka bir �ey yapma
        if (isRestarting)
            return;

        // Her frame'de oyuncunun girdi�i karakterleri kontrol et
        foreach (char c in Input.inputString)
        {
            if (c == '\b') // Backspace
            {
                if (typedWord.Length != 0)
                {
                    typedWord = typedWord.Substring(0, typedWord.Length - 1);
                    UpdateDisplayText();
                }
            }
            else if ((c == '\n') || (c == '\r')) // Enter
            {
                if (typedWord == targetWord)
                {
                    displayText.text = "<color=green>Tebrikler!</color>";
                    StartCoroutine(LoadSpecificSceneAfterDelay(1)); // 1 saniye sonra belirli sahneye ge�i� yap
                }
                else
                {
                    displayText.text = "<color=red>Yanl��. Ba�tan yaz.</color>";
                    typedWord = ""; // Yanl�� yaz�ld���nda s�f�rlay�n
                    StartCoroutine(RestartAfterDelay(2)); // 2 saniye sonra yeniden ba�lat
                }
            }
            else
            {
                if (typedWord.Length < targetWord.Length && c == targetWord[typedWord.Length])
                {
                    typedWord += c;
                    UpdateDisplayText();
                }
                else if (typedWord.Length < targetWord.Length)
                {
                    displayText.text = "<color=red>Yanl��. Ba�tan yaz.</color>";
                    typedWord = ""; // Yanl�� yaz�ld���nda s�f�rlay�n
                    StartCoroutine(RestartAfterDelay(2)); // 2 saniye sonra yeniden ba�lat
                }
            }
        }
    }

    void UpdateDisplayText()
    {
        string result = "";
        for (int i = 0; i < targetWord.Length; i++)
        {
            if (i < typedWord.Length && typedWord[i] == targetWord[i])
            {
                result += "<color=red>" + targetWord[i] + "</color>";
            }
            else
            {
                result += "<color=white>" + targetWord[i] + "</color>";
            }
        }
        displayText.text = result;
    }

    System.Collections.IEnumerator RestartAfterDelay(float delay)
    {
        isRestarting = true;
        yield return new WaitForSeconds(delay);
        typedWord = "";
        isRestarting = false;
        UpdateDisplayText();
    }

    System.Collections.IEnumerator LoadSpecificSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Giris"); // "Giris" adl� sahneye ge�i� yap
    }
}
