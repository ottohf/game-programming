using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public float maxAmount;
    public float currentAmount;
    public UnityEvent onDeath;

    private void Awake()
    {
        currentAmount = maxAmount;

    }
    void Update()
    {
        if (currentAmount <= 0)
        {
            onDeath.Invoke();

            Destroy(gameObject);
        }
    }
}