using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    private int x;
    private int z;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-1, 2);
        z = Random.Range(-1, 2);


    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
    }
}
