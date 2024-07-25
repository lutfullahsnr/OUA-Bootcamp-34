using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip musicClip; // Çalacak müzik parçasý
    private static audio instance; // Singleton örneði
    private AudioSource audioSource;

    void Awake()
    {
        // Singleton kontrolü
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // AudioSource bileþenini al veya oluþtur
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // Müzik parçasýný yükle ve döngüye al
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            // Eðer baþka bir AudioManager varsa, bu GameObject'i yok et
            Destroy(gameObject);
        }
    }
}
