using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] LayerMask objectMask;

    Ray ray;
    RaycastHit hit;
    float radius = 0.5f;
    float maxDistance = 5f;


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
}
