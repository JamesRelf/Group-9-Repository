using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerPickup2 : MonoBehaviour
{
    [SerializeField] LayerMask objectMask;

    Ray ray;
    RaycastHit hit;
    float radius = 0.5f;
    float maxDistance = 5f;
    bool wasPickedUp;

    public string prName;
    public int prIndex;
    public float prPrice;
    public float budget = 1000f;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        TrackMouse();
        Pickup();
    }

    void TrackMouse()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.SphereCast(ray, radius, out hit, maxDistance, objectMask))
            {
                AddAndCheckItems();
                budgetCount();
            }
        }
    }

    void AddAndCheckItems()
    {
        Item hitInfo = hit.collider.GetComponent<ItemInfo>().AccessItem();
        bool wasPickedUp = Inventory.inventoryInstance.AddItem(hitInfo);
        Debug.Log("Picking up: " + hitInfo.itemCost);

        if (wasPickedUp)
        {
            hit.collider.enabled = false;
        }
    }
    void budgetCount()
    {
        Item hitInfo = hit.collider.GetComponent<ItemInfo>().AccessItem();
        prPrice = hitInfo.itemCost;
        //prIndex = hitInfo.icon;
        prName =  hitInfo._name;
        print(prPrice);
        budget = budget - prPrice;
        print(budget);
    }
}
