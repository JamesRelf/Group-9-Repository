// Code edited from Brackeys (2017) INVENTORY CODE - Making an RPG in Unity (E06). How to make an RPG in Unity. 
//[Online Video] Available at: https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7 [Accessed 11/02/2022]
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
