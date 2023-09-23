using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health_txt_UI : MonoBehaviour
{
    TextMeshProUGUI healthUI;
    Player_Base health_base;   

    private void Start()
    {        
        health_base = FindObjectOfType<Player_Base>();
        healthUI = GetComponent<TextMeshProUGUI>();        
    }

    private void Update()
    {
        healthUI.text = health_base.Health.ToString();        
    }
}
