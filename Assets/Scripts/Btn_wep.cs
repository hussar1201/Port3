using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_wep : MonoBehaviour
{
    public GameObject[] arr_img;
    public int num_btn;     

    public void clicked()
    {
        ArmManager.instance.OnBtnWepClicked(num_btn);
    }   

    public void ChangeImg(int num)
    {
        if (num_btn != num) return;

        for (int i = 0; i < arr_img.Length; i++)
        {                   
            arr_img[i].SetActive(!arr_img[i].activeInHierarchy);
        }
    }



}
