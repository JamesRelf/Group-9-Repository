using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject, IUseable
{
    public string _name = "New Item";
    public Sprite icon = null;
    public int itemCost;
    public GameObject productInformation;

    public virtual void Use()
    {
        //Do Something with the items
        productInformation.SetActive(true);
    }

    public void UseItem(GameObject infoScreen)
    {
        infoScreen.SetActive(true);
    }

    public void CloseScreen(GameObject infoScreen)
    {
        infoScreen.SetActive(false);
    }
}
