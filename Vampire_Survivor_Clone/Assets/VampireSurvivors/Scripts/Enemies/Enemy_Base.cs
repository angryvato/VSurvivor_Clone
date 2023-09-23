using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Base : MonoBehaviour
{
    public float _health = 10.0f;
    public float damage = 5.0f;
    Player_Base _player;
    private bool canDealDamage = true;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    private void Start()
    {
        _player = FindObjectOfType<Player_Base>();  
    }
    
    private void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {       

        if(_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }       

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && canDealDamage)
        {            
            if (_player != null)
            {
                _player.TakingDamage(damage);                
                StartCoroutine(DamagePlayer());
            }

        }
    }

    private IEnumerator DamagePlayer()
    {
        canDealDamage = false;
        yield return new WaitForSeconds(1);
        canDealDamage = true;
    }
}
