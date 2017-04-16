using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    public InventoryManager.Slot TypeOfItem = InventoryManager.Slot.INVENTORY;

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());

        parentToReturnTo = transform.parent;
        placeholderParent = parentToReturnTo;
        transform.SetParent(transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        InventoryManager.Instance.OnDragItem(TypeOfItem, parentToReturnTo.GetComponent<Dropzone>().TypeOfItem);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        //int newSiblingIndex = placeholderParent.childCount;

        //for(int i = 0;i < placeholderParent.childCount; i++)
        //{
        //    if(transform.position.x < placeholderParent.GetChild(i).position.x)
        //    {
        //        newSiblingIndex = i;

        //        if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
        //        {
        //            newSiblingIndex--;
        //        }

        //        break;
        //    }
        //}

        //placeholder.transform.SetSiblingIndex(newSiblingIndex);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentToReturnTo);
        transform.position = parentToReturnTo.position;
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);
        InventoryManager.Instance.OnDropItem(TypeOfItem, parentToReturnTo.GetComponent<Dropzone>().TypeOfItem);
    }
}