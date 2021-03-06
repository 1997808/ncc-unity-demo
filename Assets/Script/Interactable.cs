using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Detection variable")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.8f;
    public LayerMask detectionLayer;
    private GameObject detectedObject;

    //[Header("List")]
    //public List<GameObject> pickedItems = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;
        } else
        {
            detectedObject = obj.gameObject;
            return true;
        }
    }

    //public void PickUpItem(GameObject item)
    //{
    //    pickedItems.Add(item);
    //}

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
    //}
}
