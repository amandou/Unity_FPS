using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickObject : MonoBehaviour
{
    public Button itemButton;

    public void AddObject()
    {
        for (int i = 0; i < Inventory.instance.slots.Count; i++)
        {
            if (Inventory.instance.isEmpty[i])
            {
                Inventory.instance.isEmpty[i] = false;
                Instantiate(itemButton, Inventory.instance.slots[i].transform, false);
                break;
            }
        }
    }
}
