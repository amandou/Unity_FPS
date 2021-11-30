using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public Material highlightMaterial;
    public Material defaultMaterial;

    private Transform selection;

    void Update()
    {

        if (selection != null)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit.CompareTag("Object"))
            {
                var selectionRenderer = objectHit.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    if (Input.GetMouseButtonDown(0))
                    {
                        objectHit.gameObject.SetActive(false);
                    }
                }
                selection = objectHit;
            }
        }
    }
}
