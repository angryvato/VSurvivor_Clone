using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Base : MonoBehaviour
{
    public float _health = 100.0f;
    public Image _hpDisplay;
    public string hpText;
    public float Health
    {
        get
        {
            return _health;
        }
        private set
        {
            _health = value;
        }
    }

    private void Update()
    {
        hpText = Health.ToString();
        CheckHealth();
    }

    void CheckHealth()
    {
        _hpDisplay.fillAmount = (Health / 100);

        if(Health <= 0)
        {
            Debug.Log("YOU DIED!");
        }
    }

    public void TakingDamage(float _incDamage)
    {
        Debug.Log("In TakingDamage on Player_Base");
        Health -= _incDamage;
    }
}
