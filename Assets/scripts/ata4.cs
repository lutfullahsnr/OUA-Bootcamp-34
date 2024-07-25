using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Sahne geçiþi için gerekli

public class ata4 : MonoBehaviour
{
    public TMP_Text displayText; // Ekranda gösterilecek metin için referans
    private string targetWord = "Siz bizim Çekoslavakyalýlaþtýrdýklarýmýzdan mýsýnýz yoksa Çekoslavakyalýlaþtýramadýklarýmýzdan mýsýnýz?"; // Hedef kelime
    private string typedWord = ""; // Oyuncunun yazdýðý kelime
    private bool isRestarting = false; // Yeniden baþlama durumu

    void Start()
    {
        // Baþlangýçta hedef kelimeyi beyaz olarak ekrana yazdýr
        UpdateDisplayText();
    }

    void Update()
    {
        // Yeniden baþlama sürecindeyken baþka bir þey yapma
        if (isRestarting)
            return;

        // Her frame'de oyuncunun girdiði karakterleri kontrol et
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
                    StartCoroutine(LoadNextSceneAfterDelay(1)); // 1 saniye sonra sahneyi deðiþtir
                }
                else
                {
                    displayText.text = "<color=red>Yanlýþ. Baþtan yaz.</color>";
                    typedWord = ""; // Yanlýþ yazýldýðýnda sýfýrlayýn
                    StartCoroutine(RestartAfterDelay(2)); // 2 saniye sonra yeniden baþlat
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
                    displayText.text = "<color=red>Yanlýþ. Baþtan yaz.</color>";
                    typedWord = ""; // Yanlýþ yazýldýðýnda sýfýrlayýn
                    StartCoroutine(RestartAfterDelay(2)); // 2 saniye sonra yeniden baþlat
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

    System.Collections.IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
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
