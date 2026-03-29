using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int level = 1;
    public int currentXP = 0;
    public int nextLevelXP = 10;

    bool isChoosingUpgrade = false;

    PlayerController playerController;
    PlayerHealth playerHealth;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (!isChoosingUpgrade) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerController.UpgradeFireRate();
            FinishUpgrade();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerController.UpgradeRange();
            FinishUpgrade();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            playerHealth.UpgradeMaxHP();
            FinishUpgrade();
        }
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= nextLevelXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        currentXP = 0;
        nextLevelXP += 5;

        isChoosingUpgrade = true;
        Time.timeScale = 0f;

        Debug.Log("LEVEL UP");
        Debug.Log("1: 攻撃速度UP");
        Debug.Log("2: 射程UP");
        Debug.Log("3: 最大HPUP");
    }

    void FinishUpgrade()
    {
        isChoosingUpgrade = false;
        Time.timeScale = 1f;
        Debug.Log("強化選択完了");
    }

    void OnGUI()
    {
        if (!isChoosingUpgrade) return;

        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;
        style.normal.textColor = Color.black;

        GUI.Label(new Rect(20, 20, 400, 40), "LEVEL UP!", style);
        GUI.Label(new Rect(20, 60, 400, 40), "1: 攻撃速度UP", style);
        GUI.Label(new Rect(20, 100, 400, 40), "2: 射程UP", style);
        GUI.Label(new Rect(20, 140, 400, 40), "3: 最大HPUP", style);
    }
}