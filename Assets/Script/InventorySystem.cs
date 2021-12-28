using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public bool isOpen = false;
    
    [Header("UI Item Section")]
    public GameObject ui_window;
    public Image[] item_images;

    [Header("UI Item Description")]
    public GameObject ui_description_window;
    public Image description_image;
    public Text description_title;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_window.SetActive(isOpen);
    }

    public void PickUpItem(GameObject item)
    {
        items.Add(item);
        UpdateUI();
    }

    void UpdateUI()
    {
        HideAll();
        //show in the slot in inventory
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("run 1");
            item_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            item_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach(var i in item_images) { i.gameObject.SetActive(false); }
    }
}
