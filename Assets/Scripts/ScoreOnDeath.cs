using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int pointsGivenOnDeath;
    // Start is called before the first frame update
    void Start()
    {
        var enemyLife = GetComponent<Life>();
        enemyLife.onDeath.AddListener(GivePoints);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void GivePoints()
    {
        ScoreManager.instance.amount += pointsGivenOnDeath;
    }
}
