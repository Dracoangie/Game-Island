using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{


    public AudioSource SoundTrack;
    public AudioSource Effects;

    void Awake()
    {
        SoundTrack.loop=true;
        SoundTrack.Play();
    }


    void Update()
    {
        
    }
    
   public void playEffect(AudioClip efecto){
       Debug.Log("Reproduciendo "+efecto);
       Effects.clip = efecto;
        Effects.Play();
    }

    public void CambiarVolumen(float volumen){
        Effects.volume = volumen;
    }
}
