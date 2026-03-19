using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 3;
    int currentHP;

    public GameObject xpPrefab;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Instantiate(xpPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}