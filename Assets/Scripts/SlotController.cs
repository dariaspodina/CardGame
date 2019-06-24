﻿using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SlotController : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragHandler.cardItem.transform.SetParent(transform);
        }
    }
}