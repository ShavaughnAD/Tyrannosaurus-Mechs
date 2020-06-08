using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour
{

    [System.Serializable]
    public class Pilots
    {
        public string pilotName;
        [TextArea] public string pilotDescription;
        public int damageModifier;
        public int speedModifier;
        public float coolDownModifier;
        public Sprite pilotSprite;
    }

    public class Ships
    {
        //Will Comeback and make Ships a List so that it is easier to customize & work well with for Flexibility
    }

    [Header("Ships Variables")]
    public GameObject[] playerShip;
    public Text[] playerShipNames;
    public Text[] playerShipDescription;
    public Image[] playerShipImage;

    [Header("Pilot Variables")]
    public Text[] pilotName;
    public Text[] pilotDescription;

    [Header("Screens To Bring Up")]
    public GameObject characterSelectScreen;
    public GameObject shipSelectScreen;
    public GameObject pilotSelectScreen;
    public GameObject confirmationScreen;

    [Header("Confirmation Screen Variables")]
    public Image pilotChosen;
    public Image shipChosen;

    public Transform playerStartPoint;
    public List<Pilots> pilots;

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
    }

    public void ChooseShip(int ship)
    {
        shipSelected = ship;
        shipSelectScreen.SetActive(false);
        pilotSelectScreen.SetActive(true);
        shipChosen.sprite = playerShip[shipSelected].GetComponent<SpriteRenderer>().sprite;
        shipChosen.color = playerShip[shipSelected].GetComponent<SpriteRenderer>().color;
    }

    public void ChoosePilot(int pilot)
    {
        pilotSelected = pilot;
        pilotSelectScreen.SetActive(false);
        confirmationScreen.SetActive(true);
    }

    public void ConfirmButton()
    {
        characterSelectScreen.SetActive(false);
        GameObject ship= Instantiate(playerShip[shipSelected], playerStartPoint.position, Quaternion.identity);
        playerShipMovement = ship.GetComponent<PlayerMovement>();
        GameManager.gameManager.playerShipMovement = ship.GetComponent<PlayerMovement>();
        ApplyPilotBenefits();
        GameManager.gameManager.BeginGame();
    }

    public void ReturnButton()
    {
        characterSelectScreen.SetActive(true);
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

    public void DisplayShipInfo()
    {
        for(int i = 0; i < playerShip.Length; i++)
        {
            playerShipNames[i].text = playerShip[i].GetComponent<PlayerMovement>().shipName;
            playerShipDescription[i].text = "Lives: " + playerShip[i].GetComponent<Health>().maxHealth.ToString("F0") +
                "\n" +
                playerShip[i].GetComponent<PlayerMovement>().shipDescription;
            playerShipImage[i].sprite = playerShip[i].GetComponent<SpriteRenderer>().sprite;
            playerShipImage[i].color = playerShip[i].GetComponent<SpriteRenderer>().color;
        }
    }

    public void DisplayPilotInfo()
    {
        for(int i = 0; i < pilots.Count; i++)
        {
            pilotName[i].text = pilots[i].pilotName;
            pilotDescription[i].text = pilots[i].pilotDescription;
        }
    }
}
