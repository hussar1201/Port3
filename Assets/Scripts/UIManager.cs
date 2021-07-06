using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text text_Wep_Text_Types;
    public Text text_Wep_Text_Num;
    public Button btn_Supply;
    public RawImage clipBoard;
    private bool flag_open_clipBoard = false;


    private static UIManager m_instance;
    public static UIManager instance
    {
        get
        {
            if(m_instance==null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }
            return m_instance;
        }
    }


    private void Awake()
    {

        if(instance!=this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (GameManager.instance.flag_supply) btn_Supply.gameObject.SetActive(true);
        else
        {
            btn_Supply.gameObject.SetActive(false);
            clipBoard.gameObject.SetActive(false);
            flag_open_clipBoard = false;
        }
    }


    public void SetUI_Wep()
    {
        string tmp = "";
        for(int i=0;i< WeaponManager.instance.list_cnt_Ammo.Count; i++)
        {
            tmp += "" + WeaponManager.instance.list_cnt_Ammo[i] + "\n\n";
        }

        text_Wep_Text_Num.text = tmp;

    }


    public void OnClickBtnSupply()
    {       
        if (flag_open_clipBoard)
        {
            clipBoard.gameObject.SetActive(false);
            flag_open_clipBoard = false;
        }
        else
        {
            clipBoard.gameObject.SetActive(true);
            flag_open_clipBoard = true;
        }

        if(!GameManager.instance.flag_supply)
        {
            
        }

    }


}
