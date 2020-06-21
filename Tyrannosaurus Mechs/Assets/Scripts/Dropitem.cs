using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropitem : MonoBehaviour
{
 [System.Serializable]
  public class DropCurrency
  {
    public string name;
    public GameObject item;
    public int dropRarity;
  }

    public List<DropCurrency> LootItems = new List<DropCurrency>();
    public int dropChance;

  public void LootDrop()
  {
        Debug.LogError("Called   " + gameObject.name);
     int calculateDropChance = Random.Range(0, 101);
     if (calculateDropChance > dropChance)
     {
         return;
     }
     if (calculateDropChance <= dropChance)
     {
        int itemWeight = 0;
        for (int i = 0; i < LootItems.Count; i++)
        {
          itemWeight += LootItems[i].dropRarity;
        }
        int randomValue = Random.Range(0, itemWeight);
        for (int j = 0; j < LootItems.Count; j++)
        {
           if (randomValue <= LootItems[j].dropRarity)
           {
               Instantiate(LootItems[j].item, transform.position, transform.rotation);
               return;
           }
           randomValue -= LootItems[j].dropRarity;
        }
     }
  }
}