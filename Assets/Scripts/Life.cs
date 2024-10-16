using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float amount;
    public UnityEvent onDeath;

    private void Awake()
    {
        amount = 2f;
    }
    void Update()
    {
        if (amount <= 0)
        {
            onDeath.Invoke();

            Destroy(gameObject);
        }
    }
}