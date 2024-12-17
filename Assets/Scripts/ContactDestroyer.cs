using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ContactDestroyer : MonoBehaviour
{
    private AudioSource audioSource;//for hit sound
    public AudioClip soundEffect1;
    public AudioClip soundEffect2;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("PlayerBase"))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
                audioSource.PlayOneShot(soundEffect2); // Player gets hit
            }
            else
            {
                audioSource.PlayOneShot(soundEffect1); // Enemy gets hit
            }
            var life = other.gameObject.GetComponent<Life>();
            if (life != null)
            {
                life.currentAmount -= 1;
            }
            else
            {
                Debug.LogError("hit object has no life" + other);
            }
        }
        if (gameObject.layer == LayerMask.NameToLayer("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}