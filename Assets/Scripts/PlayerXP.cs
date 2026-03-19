using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int level = 1;

    public int currentXP = 0;
    public int nextLevelXP = 0;

    public void AddXP(int amount)
    {
        currentXP += amount;

        if(currentXP >= nextLevelXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;

        currentXP = 0;
        nextLevelXP += 5;

        Debug.Log("Level Up1 Lv:" + level);
    }
}