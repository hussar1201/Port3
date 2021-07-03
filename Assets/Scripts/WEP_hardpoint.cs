using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_hardpoint : MonoBehaviour
{
    public GameObject[] arr_pack;
    public int num_hardpoint;
    public Projectilepack wep_pack;
    public int num_hellfires;
    public int num_rockets;

    public int wep_set
    {
        get;
        private set;
    }

    private void Start()
    {
        wep_set = GameManager.instance.armset[num_hardpoint];
        armset();
    }

    private void armset()
    {
        for (int i = 0; i < arr_pack.Length; i++)
        {
            arr_pack[i].SetActive(false);
        }
        
        arr_pack[wep_set].SetActive(true);
        wep_pack = GetComponentInChildren<Projectilepack>();      
    }


    public bool Fire(GameObject target)
    {      
        bool result = wep_pack.Fire(target);
        return result;
    }


    public void ChangeSet()
    {
        for (int i = 0; i < arr_pack.Length; i++)
        {
            arr_pack[i].SetActive(!arr_pack[i].activeInHierarchy);
            if (arr_pack[i].activeInHierarchy)
            {
                wep_set = i;
            }
        }
    }


}
