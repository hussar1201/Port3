using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_hellfirepack : MonoBehaviour, Projectilepack
{
    private int size_pack;
    private WEP_Hellfire[] arr_Hellfire;

    private void Awake()
    {
        arr_Hellfire = GetComponentsInChildren<WEP_Hellfire>();
        size_pack = arr_Hellfire.Length;
    }

    public bool Fire(GameObject target)
    {
        if (size_pack > 0)
        {
            arr_Hellfire[--size_pack].Fire(target);
            return true;
        }
        return false;
        
        
    }



}
