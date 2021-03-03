using UnityEngine;
using System.Linq;

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
        AudioSource s = source.ToList().First(it => !it.isPlaying);
        if(s != null)
        {
            s.clip = sound;
            s.Play();
        }
        
    }
}