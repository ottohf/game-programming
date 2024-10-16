using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (EnemiesManager.instance == null)
        {
            Debug.LogError("Tried to add enemy to empty manager");

        }
        EnemiesManager.instance.enemies.Add(this);
    }

    private void OnDestroy()
    {
        EnemiesManager.instance.enemies.Remove(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}