using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] private Life playerLife;
    [SerializeField] private Life playerBaseLife;

    void Awake()
    {
        if (playerLife != null)
        {
            playerLife.onDeath.AddListener(OnPlayerOrBaseDied);
        } else { Debug.LogError("no playerlife"); }
        playerBaseLife.onDeath.AddListener(OnPlayerOrBaseDied);

    }


    // Update is called once per frame
    void Update()
    {
        if (EnemiesManager.instance.enemies.Count <= 0 && WavesManager.instance.waves.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
        if (playerLife != null) { 

            if (playerLife.currentAmount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        }

    }
    void OnPlayerOrBaseDied() {
        SceneManager.LoadScene("LoseScreen");
    }
}
