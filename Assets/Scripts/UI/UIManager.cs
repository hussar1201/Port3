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
    public UI_Indicator_HP_Status indicator_HP_Status;

    private Slider[] arr_sliders;

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

        arr_sliders = GetComponentsInChildren<Slider>();
        
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

   

    public void SetUI_Wep(int mode)
    {
        
        string tmp = "";
        for(int i=0;i< WeaponManager.instance.list_cnt_Ammo.Count; i++)
        {
            tmp += "" + WeaponManager.instance.list_cnt_Ammo[i] + "\n\n";
            if(mode==1) arr_sliders[i].maxValue = WeaponManager.instance.list_cnt_Ammo[i];
            arr_sliders[i].value = WeaponManager.instance.list_cnt_Ammo[i];
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
