using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGroup : MonoBehaviour
{
    public List<MenuItem> menuItems;
    public RectTransform rect => GetComponent<RectTransform>();
    public void InitGroup(Transform movingPanel,GameManager gameManager) {
        foreach (var item in menuItems)
        {
            item.Init(movingPanel,gameManager);
        }
    }
}
