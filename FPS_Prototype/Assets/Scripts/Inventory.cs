using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public List<bool> isEmpty = new List<bool>();

    public static Inventory instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


}
