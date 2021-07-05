using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_hellfirepack : MonoBehaviour, Projectilepack
{
    private int size_pack;
    private int cnt=0;
    private WEP_Hellfire[] arr_Hellfire;

    private void Awake()
    {
        arr_Hellfire = GetComponentsInChildren<WEP_Hellfire>();
        size_pack = arr_Hellfire.Length;


    }

    public bool Fire(GameObject target)
    {
        if (cnt < size_pack)
        {
            Debug.Log(size_pack);
            Debug.Log(cnt);

            arr_Hellfire[cnt++].Fire(target);
            return true;
        }
        return false;
        
        
    }



}
