using Assets.Hierachy;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHierachy : MonoBehaviour
{
    /*A UI hierachy contain:
     * - feature buttons around them
     * - content
     * 
     * When a node is changing content we update the lower node
     * 
     */
    protected class ClickEvent : UnityEvent<UIHierachy>
    {

    }

    [Serializable]
    public class StructureChangedEvent : UnityEvent<UIHierachy>
    {

    }
    /// <summary>
    /// Trigger everytime structure in view has changed
    /// </summary>
    //public event UnityAction<UIHierachy> StructureChanged;
    /// <summary>
    /// distance by height from upper node to lower node
    /// </summary>
    public static int Height = -32;
    /// <summary>
    /// distance by width from parent node to children node
    /// </summary>
    public static int Width = 32;
    /// <summary>
    /// Height of this in world
    /// </summary>
    public float ActualHeight { get; private set; }
    /// <summary>
    /// Height of this self when stay alone
    /// </summary>
    protected float ChildrenHeight;
    public string Content => Data.Value;
    public StructureChangedEvent StructureChanged;
    public HierachyData Data
    {
        get => data;
        set => data = value;
    }

    /// <summary>
    /// Note that we don't expected that content of a node will be changed regurlaly
    /// </summary>
    public Text text;
    private HierachyData data;
    private bool isExpand;
    UIHierachy()
    {
        isExpand = true;
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        if (Data == null) return;
        if (Data.Parent != null)
        {
            gameObject.transform.SetParent(Data.Parent.View.transform);
        }
        text.text = data.Value;
        OnStructureChanged(this);

    }

    private void Align()
    {
        if (data.Parent == null || transform.parent == null)
        {
            return;
        }

        Vector3 location = transform.position;
        int order = data.Order;

        if (order == 1)
        {
            location.y = data.Parent.View.transform.position.y;
        }

        if (order > 1)
        {
            location.y = data.Parent[order - 2].View.transform.position.y + data.Parent[order - 2].View.ChildrenHeight;
        }

        location.y += Height;

        Vector3 parentLocation = gameObject.transform.parent.position;
        float px = parentLocation.x + Width;
        location.x = px;
        gameObject.transform.position = location;
    }

    public void Expand()
    {
        isExpand = !isExpand;

        foreach (HierachyData item in Data)
        {
            item.View.gameObject.SetActive(isExpand);
        }
        StructureChanged?.Invoke(this);
    }

    public void OnStructureChanged(UIHierachy view)
    {
        view.CalculateLocalHeight();
        view.Align();

        foreach (HierachyData item in view.data)
        {
            item.View.DescendantChanged();
        }

        if (view.data.Parent != null)
        {
            int order = data.Order;

            for (int loop = order; loop < view.data.Parent.Count; loop++)
            {
                view.data.Parent[loop].View.BrothersChanged();
            }
        }
        
    }

    private void DescendantChanged()
    {
        CalculateLocalHeight();
        Align();

        foreach (HierachyData item in data)
        {
            item.View.DescendantChanged();
        }
    }

    private void BrothersChanged()
    {
        CalculateLocalHeight();
        Align();

        foreach (HierachyData item in data)
        {
            item.View.DescendantChanged();
        }
    }

    private void CalculateLocalHeight()
    {
        if (isExpand)
        {
            ChildrenHeight = Height * data.Count;
            foreach (HierachyData item in data)
            {
                item.View.CalculateLocalHeight();
                ChildrenHeight += item.View.ChildrenHeight;
            }
        }
        else
        {
            ChildrenHeight = 0;
        }

    }
    
  
    /// <summary>
    /// Calculate actual height for itself
    /// </summary>
    private void CalculateActualHeight()
    {
        if (data.Parent == null)
        {
            ActualHeight = transform.position.y;
            return;
        }

        int order = data.Order;

        if (order == 1)
        {
            ActualHeight = data.Parent.View.transform.position.y;
        }

        if (order > 1)
        {
            ActualHeight = data.Parent[order - 2].View.transform.position.y + data.Parent[order - 2].View.ChildrenHeight;
            //ActualHeight = data.Parent[order - 2].View.ActualHeight + data.Parent[order - 2].View.ChildrenHeight;
        }

        ActualHeight += Height;
    }

    /// <summary>
    /// Create 
    /// <see cref="UIHierachy"/> 
    /// base on Prefa Resources/HierachyBase.prefab
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static UIHierachy Create(HierachyData data)
    {
        GameObject go = Resources.Load<GameObject>("HierachyBase");
        GameObject clone = Instantiate(go);
        UIHierachy view = clone.GetComponent<UIHierachy>();
        view.Data = data;
        data.View = view;

        return view;
    }

    /// <summary>
    /// Create 
    /// <see cref="UIHierachy"/>
    /// base on 
    /// <see cref="GameObject"/> hierachyBase
    /// </summary>
    /// <param name="hierachyBase"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static UIHierachy Create(GameObject hierachyBase, HierachyData data)
    {
        GameObject clone = Instantiate(hierachyBase);
        UIHierachy view = clone.GetComponent<UIHierachy>();
        view.Data = data;
        data.View = view;

        return view;
    }
}
