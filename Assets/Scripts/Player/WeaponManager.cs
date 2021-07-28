using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    private WEP_hardpoint[] arr_hardPoint;
    public static int ROCKET_PER_PACKS = 64;
    public static int HELLFIRE_PER_PACKS = 8;
    private float interval_time_hellfire = 2.0f;
    private float interval_time_rocket = .5f;
    private float interval_time_gun = .3f;
    private float lastfiretime_hellfire;
    private float lastfiretime_rocket;
    private float lastfiretime_gun;
    public Transform[] pos_fall;
    //public ParticleSystem ps_gun_tracker;
    
    public List<int> list_cnt_Ammo = new List<int>();

    public GameObject target;
    public GameObject target_before;
    public UI_HeadToCamera target_sign_locked;
    public UI_HeadToCamera target_before_sign_locked;

    private List<WEP_hardpoint> hardPoint_armed_hellfire = new List<WEP_hardpoint>();
    private List<WEP_hardpoint> hardPoint_armed_rocket = new List<WEP_hardpoint>();
    private WEP_Cannon cannon;

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
        cannon = GetComponentInChildren<WEP_Cannon>();

    }

    private void Start()
    {
        ReloadAmmo();
        lastfiretime_hellfire = lastfiretime_rocket = lastfiretime_gun = 0f;
    }


    private void Update()
    {

        if (!GameManager.instance.game_on) return;
        target = RDRController.instance.target;

        if (target != null)
        {
            target_sign_locked = target.gameObject.GetComponentInChildren<UI_HeadToCamera>();
            if (target_sign_locked != null && target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled == false)
            {
                if(target_before!=target) SoundManager.instance.playOneShotAudio(SoundManager.sounds.targetlocked,2);
                target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = true;               
            }
        }

        
        if(target_before != null && target_before != target)
        {
            target_before_sign_locked = target_before.gameObject.GetComponentInChildren<UI_HeadToCamera>();
            if (target_sign_locked != null) 
            {               
                target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (target_before_sign_locked != null) target_before_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }        
        

        target_before = target;

        if (PlayerInput.instance.fire_msl && num_hellfires > 0 &&
            Time.time > lastfiretime_hellfire + interval_time_hellfire)
        {
           
            if (target == null) return;

            for (int i = 0; i < hardPoint_armed_hellfire.Count;i++)
            {
                
                if (hardPoint_armed_hellfire[i].Fire(target) && target.gameObject.activeInHierarchy)
                {
                    SoundManager.instance.playOneShotAudio(SoundManager.sounds.engage, 2);
                    lastfiretime_hellfire = Time.time;
                    num_hellfires--;
                    list_cnt_Ammo[0] = num_hellfires;
                    target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    UIManager.instance.SetUI_Wep(0);
                    break;
                }
            }
        }

        if (PlayerInput.instance.fire_rocket && num_rockets > 0 &&
           Time.time > lastfiretime_rocket + interval_time_rocket)
        {
            
            for (int i = 0; i < hardPoint_armed_rocket.Count; i++)
            {
                if (hardPoint_armed_rocket[i].Fire(target))
                {
                    lastfiretime_rocket = Time.time;
                    num_rockets --;
                    list_cnt_Ammo[1] = num_rockets;
                    SoundManager.instance.playOneShotAudio(SoundManager.sounds.rocket,3);
                    UIManager.instance.SetUI_Wep(0);               
                    break;
                }
            }
        }


        if (PlayerInput.instance.fire_gun && Time.time > lastfiretime_gun + interval_time_gun)
        {
            lastfiretime_gun = Time.time;          
            cannon.Fire();
           
        }


    }

    public void ChangeSet(int num)
    {
        arr_hardPoint[num].ChangeSet();
        GameManager.instance.armset[num] = arr_hardPoint[num].wep_set;
    }

    public void ReloadAmmo()
    {
        arr_hardPoint.Initialize();
        arr_hardPoint = GetComponentsInChildren<WEP_hardpoint>();

        list_cnt_Ammo.Clear();
        num_rockets = 0;
        num_hellfires = 0;
        hardPoint_armed_hellfire.Clear();
        hardPoint_armed_rocket.Clear();

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

        target = target_before = null;
        

        list_cnt_Ammo.Add(num_hellfires);
        list_cnt_Ammo.Add(num_rockets);

        if (UIManager.instance != null) UIManager.instance.SetUI_Wep(1);

    }




    public void ResetTGT()
    {      
                         
        if (target != null) target_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (target_before != null && target_before_sign_locked !=null) target_before_sign_locked.gameObject.GetComponent<SpriteRenderer>().enabled = false;             
        target_sign_locked = target_before_sign_locked = null;
        target = target_before =  null;
    }

}
