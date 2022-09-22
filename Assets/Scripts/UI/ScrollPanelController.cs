using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class ScrollPanelController : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
{
    [Inject] public GameManager gameManager;
    public Transform movingPanel;
    public RectTransform viewPort;
    public RectTransform contentPanel;
    public ItemGroup itemGroupPrefab;
    public float paddingSpace = 10;
    public float itemHeight = 125;
    public int numberOfItem;
    public float totalSize;
    float size;
    public List<ItemGroup> itemGroupList = new List<ItemGroup>();
    ScrollRect scrollRect;
    // Debug.LogError(contentPanel.anchoredPosition.y);
    // Debug.LogError(viewPort.rect.width);
    // Start is called before the first frame update
    public int watch = 0;
    public int oldWatch = 0;

    Vector2 lastDragPosition;
    bool positiveDrag = false;
    void Start()
    {
        GenerateItemGroupList(gameManager);
        scrollRect = GetComponent<ScrollRect>();
        scrollRect.onValueChanged.AddListener(OnValueChanged);
    }

    void GenerateItemGroupList(GameManager gameManager)
    {
        size = itemHeight + paddingSpace;
        numberOfItem = Mathf.CeilToInt(viewPort.rect.height / size) + 1;
        totalSize = size * numberOfItem;
        for (int i = 0; i < numberOfItem; i++)
        {
            var itemGroup = Instantiate(itemGroupPrefab.gameObject, contentPanel.transform).GetComponent<ItemGroup>();
            itemGroup.gameObject.name = "ItemGroup_" + i;
            itemGroup.InitGroup(movingPanel,gameManager);
            itemGroup.rect.anchoredPosition = new Vector3(0, -i * size, 0);


            itemGroupList.Add(itemGroupPrefab);
        }
    }






    private void OnValueChanged(Vector2 arg0)
    {

        watch = Mathf.FloorToInt((contentPanel.anchoredPosition.y % totalSize) / size);
        watch = Mathf.Abs(watch);

        if (watch < 0)
        {
            watch = numberOfItem + watch;
        }

        if (oldWatch != watch)
        {
            Transform currItem;
            Transform endItem;

            int endItemIndex = 0;
            int curItemIndex = 0;
            float increment = 0; ;
            if (!positiveDrag)
            {
                curItemIndex = numberOfItem - 1;
                endItemIndex = 0;
                increment = size;
            }
            else if (positiveDrag)
            {
                endItemIndex = numberOfItem - 1;
                curItemIndex = 0;
                increment = -size;
            }
            endItem = contentPanel.GetChild(endItemIndex);
            currItem = contentPanel.GetChild(curItemIndex);
            Vector2 newPos = endItem.GetComponent<RectTransform>().anchoredPosition;
            newPos.y += increment;

            currItem.GetComponent<RectTransform>().anchoredPosition = newPos;
            currItem.SetSiblingIndex(endItemIndex);
            oldWatch = watch;
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastDragPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {

        positiveDrag = eventData.position.y > lastDragPosition.y;
        lastDragPosition = eventData.position;
    }


    public void OnScroll(PointerEventData eventData)
    {
        positiveDrag = eventData.scrollDelta.y > 0;
        Debug.LogError(eventData.scrollDelta.y);
    }

}
