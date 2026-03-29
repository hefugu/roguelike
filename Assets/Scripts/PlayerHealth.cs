using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 10;
    int currentHP;

    public float invincibleTime = 0.5f;
    float invTimer = 0f;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (invTimer > 0){
        invTimer -= Time.deltaTime;
    }
    }

    public void TakeDamage(int dmg)
    {
        if(invTimer > 0) return;

        currentHP -= dmg;
        invTimer = invincibleTime;

        Debug.Log("HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
    }

    public void UpgradeMaxHP()
    {
        maxHP += 2;
    }
}