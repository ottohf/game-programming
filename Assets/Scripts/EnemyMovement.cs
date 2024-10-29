using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    private int x;
    private int z;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        while (x == 0 && z == 0)
        {
            x = Random.Range(-1, 2);
            z = Random.Range(-1, 2);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);


        rb.AddForce(
           x * Time.deltaTime * speed * 1000,
           0,
           z * Time.deltaTime * speed * 1000
        );

        // Calculate direction based on x and z values
        Vector3 moveDirection = new Vector3(x, 0, z).normalized;

        // Only rotate if the enemy is actually moving
        if (moveDirection != Vector3.zero)
        {
            // Calculate the rotation to look in the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }
}

