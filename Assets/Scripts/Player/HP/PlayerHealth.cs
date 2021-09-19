using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private ColliderCollecter colliderCollecter;
    public enum part { Cockpit, Wing, Engine, FrameRear, TailH, TailV };
    private int[] arr_part_HP = new int[6];

    void Start()
    {
        colliderCollecter = GetComponentInChildren<ColliderCollecter>();

        for(int i =0;i<arr_part_HP.Length;i++)
        {
            arr_part_HP[i] = 3;
        }
    }

    public void OnPartDamaged(int x)
    {
        arr_part_HP[x]--;
        if (x == 5) UIManager.instance.indicator_HP_Status.Set_HP_part(x-1);
        else UIManager.instance.indicator_HP_Status.Set_HP_part(x);
    }

}
