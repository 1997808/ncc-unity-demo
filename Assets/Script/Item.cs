using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp, Examine};
    public InteractionType type;
    public string description;
    public UnityEvent customEvent;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.layer = 8;
    }

    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                Debug.Log("Pick");
                FindObjectOfType<InventorySystem>().PickUpItem(gameObject);
                gameObject.SetActive(false);
                break;
            case InteractionType.Examine:
                Debug.Log("Check");
                break;
            default:
                Debug.Log("No type");
                break;
        }
    }
}
