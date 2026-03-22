using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public AudioClip backgroundMusic;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        PlayMusic(backgroundMusic);
        GameManager.Instance.OnScoreChanged += PlayCoinSound;
        GameManager.Instance.OnHealthChanged += PlayDamageSound;
    }

    void PlayCoinSound(int score)
    {
        PlaySoundEffect(coinSound);
    }

    void PlayDamageSound(int health)
    {
        PlaySoundEffect(damageSound);
    }
    
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void PlaySoundEffect(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}