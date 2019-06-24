using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject cardItem;

    Vector3 startPosition;
    Vector3 screenPoint;
    Transform startParent;
    string parentTag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        cardItem = gameObject;
        startPosition = Camera.main.WorldToScreenPoint(transform.position);
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        parentTag = transform.parent.tag;
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = 1f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cardItem = null;

        if (transform.parent == startParent)
        {
            ResetPositionToStartPoint();
        }

        if (parentTag == "PlayerSlot" & transform.parent.tag == "Reset" | transform.parent.tag == "Deck")
        {
            ResetPositionToStartPoint();
        }

        if (parentTag == "TableSlot" & transform.parent.tag == "PlayerSlot" | transform.parent.tag == "Deck")
        {
            ResetPositionToStartPoint();
        }

        if (parentTag == "Deck" & transform.parent.tag == "TableSlot")
        {
            ResetPositionToStartPoint();
        }
        if (parentTag == "Deck" & transform.parent.tag == "Reset")
        {
            ResetPositionToStartPoint();
        }
        if (parentTag == "Reset")
        {
            ResetPositionToStartPoint();
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    void ResetPositionToStartPoint()
    {
        transform.position = Camera.main.ScreenToWorldPoint(startPosition);
        transform.SetParent(startParent);
    }
}