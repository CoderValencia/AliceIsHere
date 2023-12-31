using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class audiomanager : MonoBehaviour


{
    public sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
       DontDestroyOnLoad(gameObject);
        foreach (sound s in sounds){
        s.source= gameObject.AddComponent<AudioSource>();
        s.source.clip= s.clip;

        s.source.volume =s.volume;
        s.source.pitch= s.pitch;
        }
    }

    // Update is called once per frame
    public void Play (string name)
    {
      sound s=   Array.Find(sounds, sound => sound.name ==name);
      s.source.Play();
    }
}
