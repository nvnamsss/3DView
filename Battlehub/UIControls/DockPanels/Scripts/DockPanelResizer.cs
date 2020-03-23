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
        delta.x *= m_dx;
        delta.y *= m_dy;
        Affected.sizeDelta += delta;

        Vector2 location = Affected.position;
        location += delta / 2;

        Affected.position = location;
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
