using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] playerShip;
    public Transform playerStartPoint;

    //public Image shipSelectImage;
    public GameObject characterSelectScreen;

    void Awake()
    {
        
    }

    public void ChooseShip(int ship)
    {
        characterSelectScreen.SetActive(false);
        Instantiate(playerShip[ship], playerStartPoint.position, Quaternion.identity);
    }
}
