using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanelController : MonoBehaviour
{
    public TextMeshProUGUI unitName;
    public Button demolishButton;

    public void GenerateInfoPanel(string name, Action demolishAction)
    {
        unitName.gameObject.SetActive(true);
        unitName.text = name;
        demolishButton.onClick.RemoveAllListeners();
        demolishButton.gameObject.SetActive(true);
        demolishButton.onClick.AddListener(() => demolishAction());
    }

    public void HideInfo()
    {
        unitName.gameObject.SetActive(false);
        demolishButton.onClick.RemoveAllListeners();
        demolishButton.gameObject.SetActive(false);

    }
}
