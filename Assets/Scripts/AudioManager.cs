using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;
    public AudioClip[] clipBank;
    private Dictionary<string, AudioClip> mapper;
    private AudioSource src;
    private AudioListener listener;

	// Use this for initialization
	void Start ()
    {
		if (audioManager == null)
        {
            DontDestroyOnLoad(gameObject);
            audioManager = this;
        }
        else if (audioManager != this)
        {
            Destroy(gameObject);
        }

        src = GetComponent<AudioSource>();
        listener = GetComponent<AudioListener>();
        mapper = new Dictionary<string, AudioClip>();
        foreach (AudioClip clip in clipBank)
        {
            mapper.Add(clip.name, clip);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ChangeAudioSource(string name)
    {
        src.clip = mapper[name];
        src.Play();
    }
}
