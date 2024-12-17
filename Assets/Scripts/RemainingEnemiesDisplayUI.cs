using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;

public class RemainingEnemiesDisplayUI : MonoBehaviour
{
    // Start is called before the first frame update
    TMP_Text text;
    public EnemiesManager enemiesManager;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemies left: " + enemiesManager.enemies.Count;
    }
}
