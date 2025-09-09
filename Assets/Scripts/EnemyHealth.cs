using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int MaxHealth { get; private set; } = 3;
    [SerializeField] public int CurrentHealth { get; private set; } = 3;

    public void TakeDamage(int damage)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - Mathf.Abs(damage));
        if(CurrentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
