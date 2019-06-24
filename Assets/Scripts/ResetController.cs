using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetController : MonoBehaviour, IDropHandler
{
    Stack<GameObject> cards = new Stack<GameObject>();

    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                foreach (GameObject p in cards)
                {
                    return cards.Pop();
                }
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DragHandler.cardItem.transform.SetParent(transform);
        cards.Push(transform.GetChild(0).gameObject);
    }
}
