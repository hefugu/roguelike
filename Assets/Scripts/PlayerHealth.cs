using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
public int maxHP = 10;
int currentHP;

void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Debug.Log("Player Dead");
            Destroy(gameObject);
        }
    }
    
}
