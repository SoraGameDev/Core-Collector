using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{

    //PlayerRelatedObjects
    [SerializeField] List<cubeValue> ores = new List<cubeValue>();
    public int drillDurability;
    public int playerGold;
    public int playergoldTotal;
    GameObject player;
    [SerializeField] float xOffset = 4;
    [SerializeField] float yOffset = 4;
    Rigidbody2D rb;
    public bool StopRight;
    public bool StopLeft;
    public GameObject downArrow;

    //Triggers
    public GameObject RightTrigger;
    public GameObject LeftTrigger;
    public GameObject LowestLevelTrigger;
    public GameObject LavaTrigger;

    //Animators
    public Animator restartMenu;
    
    //Particles
    public GameObject stonePS;
    public GameObject dirtPS;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.UpdatePlayerGold(playerGold);
        drillDurability = PlayerPrefs.GetInt("drillDurability");
        UIManager.Instance.UpdateDrillDurability(drillDurability);
        
        StopRight = false;
        StopLeft = false;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        restartMenu = restartMenu.GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    
   
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == RightTrigger)
        {
            StopRight = true;

        }
        if (other.gameObject == LeftTrigger)
        {
            StopLeft = true;

        }

        if (other.gameObject == LowestLevelTrigger)
        {
            if(GameManager.Instance.armourBought == false)
            {
                restartMenu.SetBool("GameOver", true);
                GameManager.Instance.SetGold(GameManager.Instance.GetGold() + playerGold);
                playerGold = 0;
                UIManager.Instance.TotalGold();
                UIManager.Instance.UpgradeAmount();
                UIManager.Instance.ArmourAmount();

            }
            else
            {
                LowestLevelTrigger.SetActive(false);

            }


        }

        if (other.gameObject == LavaTrigger)
        {
            restartMenu.SetBool("GameOver", true);
            GameManager.Instance.SetGold(GameManager.Instance.GetGold() + playerGold);
            playerGold = 0;
            UIManager.Instance.TotalGold();
            UIManager.Instance.UpgradeAmount();
            UIManager.Instance.ArmourAmount();

        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == RightTrigger)
        {
            StopRight = false;

        }

        if (other.gameObject == LeftTrigger)
        {
            StopLeft = false;

        }
    }

    public void MoveLeft()
    {
        RaycastHit2D lefthit = Physics2D.Raycast(transform.position, Vector2.left, 1);


        
            if (lefthit.collider != null && StopLeft == false && drillDurability > 0)
            {

                //Destroy Block to the Left
                Destroy(lefthit.transform.gameObject);

                //Gain Value of Ore Collected
                if(lefthit.transform.gameObject.name == "Ground")
                {
                    dirtPS.transform.position = lefthit.transform.position;
                    dirtPS.GetComponent<ParticleSystem>().Emit(20);

                }
                if (lefthit.transform.gameObject.name == "Stone(Clone)")
                {
                    playerGold = playerGold + 5;
                    stonePS.transform.position = lefthit.transform.position;
                    stonePS.GetComponent<ParticleSystem>().Emit(20);
                }
                if (lefthit.transform.gameObject.name == "Iron(Clone)")
                {
                    playerGold = playerGold + 15;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "Gold(Clone)")
                {
                    playerGold = playerGold + 35;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "Platinum(Clone)")
                {
                    playerGold = playerGold + 50;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "Diamond(Clone)")
                {
                    playerGold = playerGold + 150;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "Uranium(Clone)")
                {
                    playerGold = playerGold + 250;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "Iridium(Clone)")
                {
                    playerGold = playerGold + 350;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
                if (lefthit.transform.gameObject.name == "CorePiece(Clone)")
                {
                    playerGold = playerGold + 600;
                stonePS.transform.position = lefthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }

            UIManager.Instance.UpdatePlayerGold(playerGold);

                //Movement
                player.transform.position = new Vector2(player.transform.position.x - xOffset, player.transform.position.y);

                //Drill Durability Down
                drillDurability = drillDurability - 1;
            UIManager.Instance.UpdateDrillDurability(drillDurability);

            //End of Rounds
            if (drillDurability < 1)
            {
                restartMenu.SetBool("GameOver", true);
                GameManager.Instance.SetGold(GameManager.Instance.GetGold() + playerGold);
                playerGold = 0;
                UIManager.Instance.TotalGold();
                UIManager.Instance.UpgradeAmount();
                UIManager.Instance.ArmourAmount();
                UIManager.Instance.TotalUpgradeGold();
                downArrow.SetActive(false);
            }

        }
            else
            {
                //Move when there is an Empty Block
                if (StopLeft == false && drillDurability > 0)
                {
                    player.transform.position = new Vector2(player.transform.position.x - xOffset, player.transform.position.y);
                }


            }
        }
    public void MoveRight()
    {
        RaycastHit2D righthit = Physics2D.Raycast(transform.position, Vector2.right, 1);



        if (righthit.collider != null && StopRight == false && drillDurability > 0)
        {

            //Destroy Block to the Right
            Destroy(righthit.transform.gameObject);

            //Gain Value of Ore Collected
            if (righthit.transform.gameObject.name == "Ground")
            {
                dirtPS.transform.position = righthit.transform.position;
                dirtPS.GetComponent<ParticleSystem>().Emit(20);

            }
            if (righthit.transform.gameObject.name == "Stone(Clone)")
            {
                playerGold = playerGold + 5;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Iron(Clone)")
            {
                playerGold = playerGold + 15;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Gold(Clone)")
            {
                playerGold = playerGold + 35;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Platinum(Clone)")
            {
                playerGold = playerGold + 50;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Diamond(Clone)")
            {
                playerGold = playerGold + 150;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Uranium(Clone)")
            {
                playerGold = playerGold + 250;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "Iridium(Clone)")
            {
                playerGold = playerGold + 350;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (righthit.transform.gameObject.name == "CorePiece(Clone)")
            {
                playerGold = playerGold + 600;
                stonePS.transform.position = righthit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            UIManager.Instance.UpdatePlayerGold(playerGold);

            //Movement
            player.transform.position = new Vector2(player.transform.position.x + xOffset, player.transform.position.y);

            //Drill Durability Down
            drillDurability = drillDurability - 1;
            UIManager.Instance.UpdateDrillDurability(drillDurability);

            //End of Rounds
            if (drillDurability < 1)
            {
                restartMenu.SetBool("GameOver", true);
                GameManager.Instance.SetGold(GameManager.Instance.GetGold() + playerGold);
                playerGold = 0;
                UIManager.Instance.TotalGold();
                UIManager.Instance.UpgradeAmount();
                UIManager.Instance.ArmourAmount();
                UIManager.Instance.TotalUpgradeGold();
                downArrow.SetActive(false);
            }
        }
        else
        {
            //Movement when there is an Empty Block
            if (StopRight == false && drillDurability > 0)
            {
                player.transform.position = new Vector2(player.transform.position.x + xOffset, player.transform.position.y);
            }

        }
    }
    public void MoveDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        hit.distance = 1;




        if (hit.collider != null && drillDurability > 0)
        {

            //Destroy the Object Below
            Destroy(hit.transform.gameObject);


            //Gain Value for Ore Collected
            if (hit.transform.gameObject.name == "Ground")
            {
                dirtPS.transform.position = hit.transform.position;
                dirtPS.GetComponent<ParticleSystem>().Emit(20);

            }
            if (hit.transform.gameObject.name == "Stone(Clone)")
            {
                playerGold = playerGold + 5;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Iron(Clone)")
            {
                playerGold = playerGold + 15;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Gold(Clone)")
            {
                playerGold = playerGold + 35;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Platinum(Clone)")
            {
                playerGold = playerGold + 50;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Diamond(Clone)")
            {
                playerGold = playerGold + 150;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Uranium(Clone)")
            {
                playerGold = playerGold + 250;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "Iridium(Clone)")
            {
                playerGold = playerGold + 350;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            if (hit.transform.gameObject.name == "CorePiece(Clone)")
            {
                playerGold = playerGold + 600;
                stonePS.transform.position = hit.transform.position;
                stonePS.GetComponent<ParticleSystem>().Emit(20);
            }
            UIManager.Instance.UpdatePlayerGold(playerGold);


            //Movement
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - yOffset);


            //Decrease Durability of Drill
            drillDurability = drillDurability - 1;
            UIManager.Instance.UpdateDrillDurability(drillDurability);

            //End of Rounds
            if (drillDurability < 1)
            {
                restartMenu.SetBool("GameOver", true);
                GameManager.Instance.SetGold(GameManager.Instance.GetGold() + playerGold);
                UIManager.Instance.TotalGold();
                playerGold = 0;
                UIManager.Instance.UpgradeAmount();
                UIManager.Instance.ArmourAmount();
                UIManager.Instance.TotalUpgradeGold();
                downArrow.SetActive(false);
            }
        }
    }


}










[System.Serializable]
    public struct cubeValue
{
    public GameObject Ore;
    public int oreValue;

}
