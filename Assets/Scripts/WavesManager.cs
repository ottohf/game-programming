using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour
{
    public static WavesManager instance;
    public List<WaveSpawner> waves;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Tried to make duplicate WavesManager, skipping it");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
