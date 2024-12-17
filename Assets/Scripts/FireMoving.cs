using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMoving : MonoBehaviour
{
    public float speed = 5f;

    private void Start()
    {
        StartCoroutine(TurnAround());

    }

    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            
            if (other.gameObject.TryGetComponent<Life>(out var life))
            {
                life.currentAmount -= 1;
            }
           
        }
    }
    private IEnumerator TurnAround()
    {
        while (true) // Infinite loop to keep turning every 5 seconds
        {
            // Wait for 5 seconds
            yield return new WaitForSeconds(5f);

            // Turn the object 180 degrees
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
