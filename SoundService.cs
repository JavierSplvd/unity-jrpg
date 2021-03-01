using UnityEngine;

public class SoundService : MonoBehaviour {
    private static SoundService _instance;

    public static SoundService Instance { get { return _instance; } }

    [SerializeField] private AudioSource[] source;
    [SerializeField] public SoundLibrarySO library;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    public void Play(AudioClip sound)
    {
        if(!source[0].isPlaying)
        {
            source[0].clip = sound;
            source[0].Play();
        }
    }
}