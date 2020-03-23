using Battlehub.UIControls.DockPanels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dockpanel3DData : MonoBehaviour
{
    public Region m_region;
    // Start is called before the first frame update
    void Start()
    {
        //m_region = GetComponent<Region>();
        GameObject content1 = new GameObject();
        content1.AddComponent<Image>().color = Color.gray;

        GameObject content2 = new GameObject();
        content2.AddComponent<Image>().color = Color.gray;

        m_region.Build(new LayoutInfo(
            isVertical: false,
            child0: new LayoutInfo(content1.transform, "Header 1"),
            child1: new LayoutInfo(content2.transform, "Header 2"),
            ratio: 0.25f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
