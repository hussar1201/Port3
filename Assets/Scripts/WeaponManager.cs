using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private WEP_hardpoint[] arr_hardPoint;
    public static int ROCKET_PER_PACKS = 64;
    public static int HELLFIRE_PER_PACKS = 8;
    private float interval_time_hellfire= 2f;
    private float interval_time_rocket = 1f;
    private float interval_time_gun = .5f;
    private float lastfiretime_hellfire;
    private float lastfiretime_rocket;
    private float lastfiretime_gun;
    public bool game_on = false;

    public List<int> list_cnt_Ammo = new List<int>();

    public GameObject target;
    public GameObject target_before;
    public UI_HeadToCamera target_sign_locked;
    public UI_HeadToCamera target_before_sign_locked;



    private List<WEP_hardpoint> hardPoint_armed_hellfire = new List<WEP_hardpoint>();
    private List<WEP_hardpoint> hardPoint_armed_rocket = new List<WEP_hardpoint>();

    public int num_rockets
    {
        get;
        private set;
    }
    public int num_hellfires
    {
        get;
        private set;
    }

    private static WeaponManager m_instance;
    public static WeaponManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<WeaponManager>();
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

        arr_hardPoint = GetComponentsInChildren<WEP_hardpoint>();
        num_rockets = 0;
        num_hellfires = 0;
    }

    private void Start()
    {
        
        for (int i = 0; i < arr_hardPoint.Length; i++)
        {
            switch (arr_hardPoint[i].wep_set)
            {
                case 0:
                    num_hellfires += HELLFIRE_PER_PACKS;
                    arr_hardPoint[i].num_hellfires = HELLFIRE_PER_PACKS;
                    hardPoint_armed_hellfire.Add(arr_hardPoint[i]);
                    break;

                case 1:
                    num_rockets += ROCKET_PER_PACKS;
                    arr_hardPoint[i].num_rockets = ROCKET_PER_PACKS;
                    hardPoint_armed_rocket.Add(arr_hardPoint[i]);
                    break;
            }
        }
        
        lastfiretime_hellfire = Time.time;
        if (GameManager.instance.game_on == null) game_on = false;
        else game_on = true;
        target_before = null;

        list_cnt_Ammo.Add(num_hellfires);
        list_cnt_Ammo.Add(num_rockets);

    }


    private void Update()
    {
        if (!game_on) return;
        target = RDRController.instance.target;

        if (target != null)
        {
            target_sign_locked = target.gameObject.GetComponentInChildren<UI_HeadToCamera>();
            if (target_sign_locked != null && target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled == false)
            {
                Debug.Log("IN1");              
                
                if(target_before!=target) SoundManager.instance.playOneShotAudio(SoundManager.sounds.targetlocked);

                target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = true;               
            }
        }

        /* RDRController 사용전 필요했던 코드
        if(target_before != null && target_before != target)
        {
            target_before_sign_locked = target_before.gameObject.GetComponentInChildren<UI_HeadToCamera>();
            if (target_sign_locked != null) 
            {               
                target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (target_before_sign_locked != null) target_before_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        */

        target_before = target;

        if (PlayerInput.instance.fire_msl && num_hellfires > 0 &&
            Time.time > lastfiretime_hellfire + interval_time_hellfire)
        {
            Debug.Log(target);

            if (target == null) return;

            for (int i = 0; i < hardPoint_armed_hellfire.Count;i++)
            {
                if (hardPoint_armed_hellfire[i].Fire(target) && target.gameObject.activeInHierarchy)
                {
                    SoundManager.instance.playOneShotAudio(SoundManager.sounds.engage);
                    lastfiretime_hellfire = Time.time;
                    num_hellfires--;
                    target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;                   
                    break;
                }
            }
        }

        list_cnt_Ammo[0] = num_hellfires;
        list_cnt_Ammo[1] = num_rockets;

        UIManager.instance.SetUI_Wep();

    }

    public void ChangeSet(int num)
    {
        arr_hardPoint[num].ChangeSet();
    }


    public void ResetTGT()
    {      
                         
        if (target != null) target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (target_before != null && target_before_sign_locked !=null) target_before_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;             
        target_sign_locked = target_before_sign_locked = null;
        target = target_before =  null;
    }

}
