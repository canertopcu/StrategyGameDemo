using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class MenuItem : MonoBehaviour, IDragHandler
{
    private Transform rememberPanel;
    private Transform movingPanel;
    private Vector3 old;
    private EventTrigger eventTrigger;
    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private Image mainImage;
    private void OnEnable()
    {
        mainImage = GetComponent<Image>();
        eventTrigger = GetComponent<EventTrigger>(); //you need to have an EventTrigger component attached this gameObject
        entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerDown;
        entry1.callback.AddListener(OnPressedDown);
        eventTrigger.triggers.Add(entry1);

        entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerUp;
        entry2.callback.AddListener(OnPressedUp);
        eventTrigger.triggers.Add(entry2);


    }

    private void OnDisable()
    {
        entry1.callback.RemoveListener(OnPressedDown);
        entry2.callback.RemoveListener(OnPressedUp);
    }

    public void Init(Transform movingPanel)
    {
        this.movingPanel = movingPanel;
    }


    private void OnPressedDown(BaseEventData arg0)
    {
        rememberPanel = transform.parent;
        old = transform.localPosition;

        transform.SetParent(movingPanel);
    }
    private void OnPressedUp(BaseEventData arg0)
    {
        transform.SetParent(rememberPanel);
        transform.localPosition = old;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
