using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        WeaponManager.instance.ChangeSet(num);
        for (int i = 0; i < btn_wep.Length; i++)
        {
            
            btn_wep[i].ChangeImg(num);           
        }

    }






}
