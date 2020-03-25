using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCubeFace : MonoBehaviour {

    private Material material;
    private MeshRenderer meshRender;

    public Color HightLightCl;
    private Color normalColor;
    public string Face = "Front";

    private void Start()
    {
        meshRender = gameObject.GetComponent<MeshRenderer>();
        material = meshRender.material;
        material.color = HightLightCl;
        meshRender.enabled = false;
    }
    // Use this for initialization
    private void OnMouseEnter()
    {
        meshRender.enabled = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Hi mom" + Face);
    }

    private void OnMouseExit()
    {
        meshRender.enabled = false;
    }
}
