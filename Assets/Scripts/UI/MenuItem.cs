using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public abstract class MenuItem : MonoBehaviour, IDragHandler
{
    private GameManager gameManager;
    private Transform rememberPanel;
    private Transform movingPanel;
    private Vector3 old;
    private EventTrigger eventTrigger;
    private EventTrigger.Entry entry1;
    private EventTrigger.Entry entry2;
    private Image mainImage;
    public GridBox selectedBox;
    public int sizeX = 1;
    public int sizeY = 1;
    public Color color;
    public GameObject WorldVisual;

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

    public void Init(Transform movingPanel, GameManager gameManager)
    {
        this.movingPanel = movingPanel;
        this.gameManager = gameManager;
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

        if (selectedBox != null)
        {
            if (isCheckedSelectedPlace)
            {
                gameManager.gridManager.FinalizeBoxes(selectedBox, this);
            }
            else
            {
                gameManager.gridManager.UncheckBoxes(selectedBox, this);
            }
        }
    }


    bool isCheckedSelectedPlace = false;

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("GridBox"))
            {
                var box = hit.transform.GetComponent<GridBox>();
                if (box != null)
                {
                    if (selectedBox == null)
                    {
                        selectedBox = box;
                    }
                    else
                    {
                        if (selectedBox != box)
                        {
                            gameManager.gridManager.UncheckBoxes(selectedBox, this);
                            selectedBox = box;
                        }
                    }

                    isCheckedSelectedPlace = gameManager.gridManager.CheckBoxes(selectedBox, this);
                }

            }
        }

        transform.position = eventData.position;
    }
}
