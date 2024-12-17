using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Reflection;

public class ScoreDisplayUI : MonoBehaviour
{
    public ScoreManager scoreManager;
    TMP_Text text;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemies smoked: " + ScoreManager.instance.amount;
    }
}
