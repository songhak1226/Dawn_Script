using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSpawner : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip EffectBGM;
    public float DestroyTime = 5.0f;


    void StartBGM()
    {
        audioSource.clip = EffectBGM;
        audioSource.Play();

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("StartBGM", 1.0f, 2);
        Destroy(gameObject, DestroyTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
