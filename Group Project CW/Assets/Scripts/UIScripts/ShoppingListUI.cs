using TMPro;
using UnityEngine;

public class ShoppingListUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] text;
    [SerializeField] Item[] item;

    
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangeCallback += UpdateShoppingList;

        SetShoppingList();
    }


    void SetShoppingList()
    {
        for(int i = 0; i < text.Length; i++)
        {
            text[i].text = item[i].name;
        }
    }

    void UpdateShoppingList()
    {
        for(int i = 0; i < text.Length; i++)
        {
            for(int j = 0; j < inventory.items.Count; j++)
            {
                if (text[i].text == inventory.items[j].name)
                {
                    text[i].fontStyle = FontStyles.Strikethrough;
                }
            }
        }
    }
}
