using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour
{

    [System.Serializable]
    public class Pilots
    {
        public string pilotName;
        [TextArea]
        public string pilotDescription;
        public int damageModifier;
        public int speedModifier;
        public float coolDownModifier;
    }

    public GameObject[] playerShip;
    public Transform playerStartPoint;
    public Text[] playerShipDescription;

    //public Image shipSelectImage;
    public GameObject characterSelectScreen;
    public GameObject pilotSelectScreen;

    public List<Pilots> pilots;

    int shipSelected = 0;
    int pilotSelected = 0;

    PlayerMovement playerShipMovement;

    void Awake()
    {
        DisplayShipInfo();
    }

    public void ChooseShip(int ship)
    {
        shipSelected = ship;
        pilotSelectScreen.SetActive(true);
        playerShipMovement = playerShip[shipSelected].GetComponent<PlayerMovement>();
    }

    public void ChoosePilot(int pilot)
    {
        pilotSelected = pilot;
        playerShipMovement.coolDownTimer += pilots[pilotSelected].coolDownModifier;
        playerShipMovement.moveSpeed += pilots[pilotSelected].speedModifier;
        playerShipMovement.weaponDamage += pilots[pilotSelected].damageModifier;
        //switch (pilotSelected)
        //{
        //    case 0:
        //        playerShipMovement.coolDownTimer = pilots[pilotSelected].coolDownModifier;
        //        playerShipMovement.moveSpeed = pilots[pilotSelected].speedModifier;
        //        playerShipMovement.weaponDamage = pilots[pilotSelected].damageModifier;
        //        break;

        //    case 1:
        //        playerShipMovement.coolDownTimer = pilots[pilotSelected].coolDownModifier;
        //        playerShipMovement.moveSpeed = pilots[pilotSelected].speedModifier;
        //        playerShipMovement.weaponDamage = pilots[pilotSelected].damageModifier;
        //        break;

        //    case 2:
        //        playerShipMovement.coolDownTimer = pilots[pilotSelected].coolDownModifier;
        //        playerShipMovement.moveSpeed = pilots[pilotSelected].speedModifier;
        //        playerShipMovement.weaponDamage = pilots[pilotSelected].damageModifier;
        //        break;
        //}
    }

    public void Confirm()
    {
        characterSelectScreen.SetActive(false);
        Instantiate(playerShip[shipSelected], playerStartPoint.position, Quaternion.identity);
        GameManager.gameManager.playerMovement = playerShipMovement;
        GameManager.gameManager.BeginGame();
    }

    public void EnableDisableScreen(GameObject enable, GameObject disable)
    {
        enable.SetActive(true);
        disable.SetActive(false);
    }

    public void DisplayShipInfo()
    {
        for(int i = 0; i < playerShip.Length; i++)
        {
            playerShipDescription[i].text = "Health: " + playerShip[i].GetComponent<Health>().maxHealth.ToString("F0") +
                "\n" +
                playerShip[i].GetComponent<PlayerMovement>().shipDescription;
        }
    }
}
