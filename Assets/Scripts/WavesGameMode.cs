using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;

    void Awake()
    {
        playerLife.onDeath.AddListener(OnPlayerDied);
        

    }


    // Update is called once per frame
    void Update()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (playerLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }

    }
    void OnPlayerDied() {
        SceneManager.LoadScene("LoseScreen");
    }
}
