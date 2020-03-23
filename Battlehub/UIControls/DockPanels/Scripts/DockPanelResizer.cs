using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DockPanelResizer : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform Affected;
    [SerializeField]
    private float m_dx = -1;
    [SerializeField]
    private float m_dy = -1;
    private Vector2 m_adjustment;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 position = eventData.position;
        Camera camera = eventData.pressEventCamera;
        Debug.Log("Hi mom Begin Drag");

        RectTransform rt = (RectTransform)transform;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, position, camera, out m_adjustment);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Hi mom Dragging");

        Vector2 delta = eventData.delta;
        delta.x *= Mathf.Abs(m_dx);
        delta.y *= Mathf.Abs(m_dy);


        if (m_dx < 0)
        {
            Affected.AddLeft(delta.x);
        }

        if (m_dx > 0)
        {
            Affected.AddRight(delta.x);
        }

        if (m_dy > 0)
        {
            Affected.AddTop(delta.y);
        }

        if (m_dy < 0)
        {
            Affected.AddBottom(delta.y);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Hi mom End Drag");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hi mom Entering");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

 public static class RectTransformExtensions
{
    public static void AddLeft(this RectTransform rt, float left)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x + left, rt.offsetMin.y);
    }

    public static void AddRight(this RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x + right, rt.offsetMax.y);
    }

    public static void AddTop(this RectTransform rt, float top)
    {
        rt.offsetMax = new Vector2(rt.offsetMax.x, rt.offsetMax.y + top);
    }

    public static void AddBottom(this RectTransform rt, float bottom)
    {
        rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y + bottom);
    }
}
