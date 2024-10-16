using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{
    // time before destruction
    public int destructionTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        // Destroy the game object after 'destructionTime' seconds
        Destroy(gameObject, destructionTime);
    }
}
