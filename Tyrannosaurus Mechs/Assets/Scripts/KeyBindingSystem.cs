using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindingSystem : MonoBehaviour
{
    public static KeyBindingSystem keyBinding;
    Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Color normalColor;
    public Color clickedColor;

    public Text moveUp, moveDown, moveLeft, moveRight, useAbility, pauseGame;
     
    GameObject currentKey;

    void Awake()
    {
        Cursor.visible = true;
        keyBinding = this;
    }

    void Start()
    {
        #region Filling Dictionary

        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "UpArrow")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "DownArrow")));
        keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "LeftArrow")));
        keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "RightArrow")));
        keys.Add("Ability", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Ability", "Space")));
        keys.Add("Pause", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pause", "Escape")));

        moveUp.text = keys["Up"].ToString();
        moveDown.text = keys["Down"].ToString();
        moveLeft.text = keys["Left"].ToString();
        moveRight.text = keys["Right"].ToString();
        useAbility.text = keys["Ability"].ToString();
        pauseGame.text = keys["Pause"].ToString();

        #endregion
    }

    void Update()
    {
        Cursor.visible = true;
    }

    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normalColor;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if(currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normalColor;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = clickedColor;
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        PlayerPrefs.Save();
    }
}
