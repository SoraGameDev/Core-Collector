using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] bool resetGame = false;
    public bool armourBought = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

       
        if (resetGame || PlayerPrefs.GetInt("Reset") != 1)
        {
            Debug.Log("reset");
            resetGame = false;
            PlayerPrefs.SetInt("playerGold", 0);
            PlayerPrefs.SetInt("drillDurability", 35);
            PlayerPrefs.SetInt("upgradeGold", 2500);
            PlayerPrefs.SetInt("armourGold", 100000);
            PlayerPrefs.SetInt("Reset", 0);
            
        }

        PlayerPrefs.SetInt("Reset", 1);
    }

    public void SetGold(int newGold)
    {   
        PlayerPrefs.SetInt("playerGold", newGold);
    }

    public int GetGold()
    {
        return PlayerPrefs.GetInt("playerGold");
    }

    public void UpgradeDrill(int newDrill)
    {
        PlayerPrefs.SetInt("drillDurability", newDrill);

    }

    public int GetDrillDurability()
    {
        return PlayerPrefs.GetInt("drillDurability");
    }

    public void SetUpgradeGoldAmount(int nextUpgrade)
    {
        PlayerPrefs.SetInt("upgradeGold", nextUpgrade);
    }

    public int GetUpgradeGoldAmount()
    {
        return PlayerPrefs.GetInt("upgradeGold");

    }

    public int GetArmourGold()
    {
        return PlayerPrefs.GetInt("armourGold");
    }
    public void ResetArmourGold(int armourReset)
    {
        PlayerPrefs.SetInt("armourGold", armourReset);
    }
}
