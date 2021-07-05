using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {              
        if (other.CompareTag("Player"))
        {      
            GameManager.instance.flag_supply = true;
            WeaponManager.instance.ReloadAmmo();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {         
            GameManager.instance.flag_supply = false;
        }
    }



}
