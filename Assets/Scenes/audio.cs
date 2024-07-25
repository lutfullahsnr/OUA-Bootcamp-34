using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip musicClip; // �alacak m�zik par�as�
    private static audio instance; // Singleton �rne�i
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton kontrol�
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // AudioSource bile�enini al veya olu�tur
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // M�zik par�as�n� y�kle ve d�ng�ye al
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            // E�er ba�ka bir AudioManager varsa, bu GameObject'i yok et
            Destroy(gameObject);
        }
    }
}
