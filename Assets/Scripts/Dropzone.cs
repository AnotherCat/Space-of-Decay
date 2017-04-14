using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    public Draggable.Slot TypeOfItem = Draggable.Slot.ITEM1;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null)
        {
            if(TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.Slot.INVENTORY)
            {
                d.parentToReturnTo = transform;
                d.transform.position = transform.position;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            if(TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.Slot.INVENTORY)
            {
                d.placeholderParent = transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null && d.parentToReturnTo == transform)
        {
            if(TypeOfItem == d.TypeOfItem || TypeOfItem == Draggable.Slot.INVENTORY)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }
}
