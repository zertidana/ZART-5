using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridObject
{
    public static GameObject inventoryTab;
    public static GameObject uiPrefab;
    private Grid<GridObject> grid;
    public int x;
    public int y;
    private GameObject itemImage;

    public ItemScriptableObject item;
    public ItemScriptableObject tempItem;


    //class constructor
    public GridObject(Grid<GridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        item = null;
    }

    //overrides tostring method so it shows both x, y and name value
    public override string ToString()
    {
        return x + ", " + y + "\n" + item.name;
    }

    //changes what object placed in this grid object
    public void SetItem(ItemScriptableObject item)
    {
        this.item = item;
        if(itemImage == null)
        {
            itemImage = GameObject.Instantiate(uiPrefab, new Vector3(0, 0, 0) * grid.GetCellSize(), Quaternion.identity, inventoryTab.transform);
        }
        itemImage.GetComponentInChildren<Image>().sprite = item.sprite;
        itemImage.GetComponentsInChildren<RectTransform>()[1].sizeDelta = grid.GetCellSize() * item.size;
        itemImage.GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0) * grid.GetCellSize();
        itemImage.GetComponentInChildren<InteractableObject>().item = item;
        itemImage.SetActive(true);
        //trigger event handler
        grid.TriggerGridObjectChanged(x, y);
    }

    //remove object from a grid position
    public void ClearItem()
    {
        item = null;
        if (itemImage != null)
        {
            itemImage.SetActive(false);
        }
        //call event handler
        grid.TriggerGridObjectChanged(x, y);
    }

    //get the object that is placed in the grid
    public ItemScriptableObject GetItem()
    {
        return item;
    }

    public void SetTemp(ItemScriptableObject item)
    {
        tempItem = item;
    }

    public bool EmptyTemp()
    {
        return tempItem == null;
    }

    public void ClearTemp()
    {
        tempItem = null;
    }

    public ItemScriptableObject GetTemp()
    {
        return tempItem;
    }

    public void SetTempAsReal()
    {
        ClearItem();
        if (!EmptyTemp())
        {
            SetItem(tempItem);
        }
        ClearTemp();
    }
}