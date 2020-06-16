using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour
{
    [System.Serializable]
    public class Pilots //Class Specifically to hold whats needed for the Pilots
    {
        public string pilotName; //Display this to a Text
        [TextArea] public string pilotDescription; //Text Area allows you to type longer strings & keep structure
        public int damageModifier; //Will +/- these values when Applying Pilot Benefits
        public int speedModifier; //Will +/- these values when Applying Pilot Benefits
        public float coolDownModifier; //Will +/- these values when Applying Pilot Benefits
        public Sprite pilotSprite; //Will display this on a Image
    }

    [System.Serializable]
    public class Ships //Class Specifically to hold data on whats needed for the Ships
    {
        public GameObject shipObj;
        public string shipName; //Display this to a Text
        [TextArea] public string shipDescription;
        public Sprite shipSprite;
        //Will Comeback and make Ships a List so that it is easier to customize & work well with for Flexibility
    }

    #region UI Variables

    [Header("Ships Variables")] 
    public GameObject[] playerShip; 
    public Text[] playerShipNames;
    public Text[] playerShipDescription;
    public Image[] playerShipImage;

    [Header("Pilot Variables")]
    public Text[] pilotName;
    public Text[] pilotDescription;
    public Image[] pilotImage;

    [Header("Screens To Bring Up")]
    public GameObject characterSelectScreen;
    public GameObject shipSelectScreen;
    public GameObject pilotSelectScreen;
    public GameObject confirmationScreen;

    [Header("Confirmation Screen Variables")]
    public Image pilotChosen;
    public Image shipChosen;

    #endregion

    public Transform playerStartPoint;
    public List<Pilots> pilots;
    public List<Ships> ships;

    int shipSelected = 0;
    int pilotSelected = 0;

    PlayerMovement playerShipMovement;

    void Awake()
    {
        DisplayPilotInfo();
        DisplayShipInfo();
        pilotSelectScreen.SetActive(false);
        confirmationScreen.SetActive(false);
        shipSelectScreen.SetActive(true);
        if(playerStartPoint == null)
        {
            Debug.LogError("PlayerStart is null, please add this in");
        }
    }

    public void ChooseShip(int ship)
    {
        shipSelected = ship;
        shipSelectScreen.SetActive(false);
        pilotSelectScreen.SetActive(true);
        //shipChosen.sprite = playerShip[shipSelected].GetComponent<SpriteRenderer>().sprite;
        shipChosen.sprite = ships[shipSelected].shipSprite;
        shipChosen.color = ships[shipSelected].shipObj.GetComponent<SpriteRenderer>().color;
        //shipChosen.color = playerShip[shipSelected].GetComponent<SpriteRenderer>().color;
    }

    public void ChoosePilot(int pilot)
    {
        pilotSelected = pilot;
        pilotChosen.sprite = pilots[pilotSelected].pilotSprite;
        pilotSelectScreen.SetActive(false);
        confirmationScreen.SetActive(true);
    }

    public void ConfirmButton()
    {
        characterSelectScreen.SetActive(false);
        //GameObject ship= Instantiate(playerShip[shipSelected], playerStartPoint.position, Quaternion.identity);
        //playerShipMovement = ship.GetComponent<PlayerMovement>();
        //GameManager.gameManager.playerShipMovement = ship.GetComponent<PlayerMovement>();

        GameObject ship = Instantiate(ships[shipSelected].shipObj, playerStartPoint.position, Quaternion.identity);
        playerShipMovement = ship.GetComponent<PlayerMovement>();
        GameManager.gameManager.playerShipMovement = playerShipMovement;

        ApplyPilotBenefits();
        GameManager.gameManager.lives = (int)ship.GetComponent<Health>().maxHealth;
        GameManager.gameManager.BeginGame();
    }

    public void ReturnButton()
    {
        characterSelectScreen.SetActive(true);
        shipSelectScreen.SetActive(true);
        pilotSelectScreen.SetActive(false);
        confirmationScreen.SetActive(false);
    }

    public void EnableDisableScreen(GameObject enable, GameObject disable)
    {
        enable.SetActive(true);
        disable.SetActive(false);
    }

    public void ApplyPilotBenefits()
    {
        playerShipMovement.coolDownTimer += pilots[pilotSelected].coolDownModifier;
        playerShipMovement.moveSpeed += pilots[pilotSelected].speedModifier;
        playerShipMovement.weaponDamage += pilots[pilotSelected].damageModifier;
    }

    #region Display Information Functions

    public void DisplayShipInfo()
    {
        //for(int i = 0; i < playerShip.Length; i++)
        //{
        //    playerShipNames[i].text = playerShip[i].GetComponent<PlayerMovement>().shipName;
        //    playerShipDescription[i].text = "Lives: " + playerShip[i].GetComponent<Health>().maxHealth.ToString("F0") +
        //        "\n" +
        //        playerShip[i].GetComponent<PlayerMovement>().shipDescription 
        //        + "\n" +
        //        "Ability: " + playerShip[i].GetComponent<PlayerMovement>().ability.ToString();

        //    playerShipImage[i].sprite = playerShip[i].GetComponent<SpriteRenderer>().sprite;
        //    playerShipImage[i].color = playerShip[i].GetComponent<SpriteRenderer>().color;


        //}

        for(int i = 0; i < ships.Count; i++)
        {
            playerShipNames[i].text = ships[i].shipName;

            playerShipDescription[i].text = "Lives: " + ships[i].shipObj.GetComponent<Health>().maxHealth.ToString("F0") +
                "\n" +
                ships[i].shipDescription + "\n" + "Ability: " + ships[i].shipObj.GetComponent<PlayerMovement>().ability.ToString();

            playerShipImage[i].sprite = ships[i].shipSprite;
            playerShipImage[i].color = ships[i].shipObj.GetComponent<SpriteRenderer>().color;
        }
    }

    public void DisplayPilotInfo()
    {
        for(int i = 0; i < pilots.Count; i++)
        {
            pilotName[i].text = pilots[i].pilotName;
            pilotDescription[i].text = pilots[i].pilotDescription;
            pilotImage[i].sprite = pilots[i].pilotSprite;
        }
    }

    #endregion
}