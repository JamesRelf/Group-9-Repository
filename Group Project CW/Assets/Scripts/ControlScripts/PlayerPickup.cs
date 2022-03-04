using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] LayerMask objectMask;

    Ray ray;
    RaycastHit hit;
    float radius = 1f;
    float maxDistance = 2f;

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
            print("Firing ray");
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
        bool wasPickedUp = Inventory.instance.AddItem(hitInfo);
        Debug.Log("Picking up: " + hitInfo.name);

        if (wasPickedUp)
        { 
            hit.collider.enabled = false;
        }
    }
    void budgetCount()
    {
        Item hitInfo2 = hit.collider.GetComponent<ItemInfo>().AccessItem();
        prPrice = hitInfo2.itemCost;
        //prIndex = hitInfo.icon;
        prName = hitInfo2.name;
        print(prPrice);
        budget = budget - prPrice;
        print(budget);
    }
    //public void budgetCount()
    //{
    //    var details = hit.collider.GetComponent<ProductDetails>();
    //    prPrice = details.ProdPrice;
    //    prIndex = details.ProdIndex;
    //    prName = details.ProdName;
    //    budget = budget - prPrice;
    //    print(budget);
    //}
}
