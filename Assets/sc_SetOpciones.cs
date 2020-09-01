using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sc_SetOpciones : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolumen(float volumen) 
    {
        float Vol_tras = volumen * (-80);
        audioMixer.SetFloat("vol", Vol_tras);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
