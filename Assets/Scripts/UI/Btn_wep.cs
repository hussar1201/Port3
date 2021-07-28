using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_wep : MonoBehaviour
{
    public GameObject[] arr_img;
    public int num_btn;


    private void Start()
    {

        int set_of_hardpoint = GameManager.instance.armset[num_btn];
        for (int i = 0; i < arr_img.Length; i++)
        {
            if(i==set_of_hardpoint) arr_img[i].SetActive(true);
             else arr_img[i].SetActive(false);
        }
    }


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
