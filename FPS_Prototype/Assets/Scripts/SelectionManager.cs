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
            var objectRenderer = selection.GetComponent<Renderer>();
            objectRenderer.material = defaultMaterial;
            selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit.CompareTag("Object"))
            {
                var objectRenderer = objectHit.GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    objectRenderer.material = highlightMaterial;
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
