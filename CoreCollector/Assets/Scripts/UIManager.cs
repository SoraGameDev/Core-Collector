using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text playerGold;
    [SerializeField] Text drillDurability;
    [SerializeField] Text totalGold;
    [SerializeField] Text upgradeAmount;
    [SerializeField] Text armourAmount;
    [SerializeField] Text totalGoldUpgrade;
    CharacterMovement characterMovement;
    int gold;
    int drill;
    public int scenetoLoad = 2;
    public static UIManager Instance;

    void Awake()
    {
        Instance = this;
        characterMovement = GameObject.Find("Player").GetComponent<CharacterMovement>();
    
    }


    // Start is called before the first frame update
    void Start()
    {
        gold = characterMovement.playerGold;
        drill = characterMovement.drillDurability;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void UpdatePlayerGold(int gold)
    {

        playerGold.text = gold.ToString();

    }

    public void UpdateDrillDurability(int drill)
    {
        drillDurability.text = drill.ToString() ;


    }

    public void LoadGame()
    {
        SceneManager.LoadScene(scenetoLoad);
        



    }

    public void GoToMainMenu()
    {

        SceneManager.LoadScene(1);
    }

    public void UpgradeDrill()
    { if (PlayerPrefs.GetInt("playerGold") >= GameManager.Instance.GetUpgradeGoldAmount())
        {

            GameManager.Instance.SetGold(GameManager.Instance.GetGold() - GameManager.Instance.GetUpgradeGoldAmount());
            GameManager.Instance.UpgradeDrill(GameManager.Instance.GetDrillDurability() + 35);
            GameManager.Instance.SetUpgradeGoldAmount(GameManager.Instance.GetUpgradeGoldAmount() + 2500);
            UpdateMenus();
     
        }
    }

    public void TotalGold()
    {
        totalGold.text = PlayerPrefs.GetInt("playerGold").ToString();
    }

    public void TotalUpgradeGold()
    {
        totalGoldUpgrade.text = PlayerPrefs.GetInt("playerGold").ToString();
    }

    public void UpgradeAmount()
    {
        upgradeAmount.text = PlayerPrefs.GetInt("upgradeGold").ToString();
    }
    public void ArmourAmount()
    {
        armourAmount.text = PlayerPrefs.GetInt("armourGold").ToString();
    }

    public void UpdateMenus()
    {
        totalGold.text = PlayerPrefs.GetInt("playerGold").ToString();
        upgradeAmount.text = PlayerPrefs.GetInt("upgradeGold").ToString();
        totalGoldUpgrade.text = PlayerPrefs.GetInt("playerGold").ToString();




    }

    //TODO remove Debug
    public void ResetGold()
    {
        PlayerPrefs.SetInt("playerGold", 0);
        PlayerPrefs.SetInt("drillDurability", 35);
        PlayerPrefs.SetInt("upgradeGold", 2500);
        GameManager.Instance.armourBought = false;
        PlayerPrefs.SetInt("armourGold", 100000);
    }


    

    public void UpgradeArmour()
    {
        if (PlayerPrefs.GetInt("playerGold") >= GameManager.Instance.GetArmourGold())
        {

            GameManager.Instance.SetGold(GameManager.Instance.GetGold() - GameManager.Instance.GetArmourGold());

            GameManager.Instance.armourBought = true;

            GameManager.Instance.ResetArmourGold(GameManager.Instance.GetArmourGold() - 100000);

            TotalGold();
            TotalUpgradeGold();
        }

    }
}
