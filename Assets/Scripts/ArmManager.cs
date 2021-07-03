using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArmManager : MonoBehaviour
{
    public Btn_wep[] btn_wep;
    public WeaponManager[] hardPoint;
    private static ArmManager m_instance;

    public static ArmManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ArmManager>();
            }           
            return m_instance;
        }
    }

    private void Awake()
    {
        if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void OnBtnWepClicked(int num)
    {      
        GameManager.instance.ChangeSet(num);
        for (int i = 0; i < btn_wep.Length; i++)
        {           
            btn_wep[i].ChangeImg(num);           
        }

    }


    public void StartGame()
    {
        PlayerPrefs.SetInt("value_armset0", GameManager.instance.armset[0]);
        PlayerPrefs.SetInt("value_armset1", GameManager.instance.armset[1]);
        SceneManager.LoadScene("Game_Lv1");
    }






}
