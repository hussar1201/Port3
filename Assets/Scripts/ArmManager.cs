using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ArmManager : MonoBehaviour
{
    public Btn_wep[] btn_wep;
    public WEP_hardpoint[] hardPoints;
    private static ArmManager m_instance;
    public Image cinePlayer;
    public RawImage playScreen;
    private bool play_over = false;
    private VideoPlayer vp;
    bool flag_played = false;
    bool flag_load_started = false;
    AsyncOperation asyncOper;
    double time_to_play;
    double time_check;
    ChopperManager check_isInMenuArming;

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

    private void Start()
    {
        check_isInMenuArming = FindObjectOfType<ChopperManager>();
        if(check_isInMenuArming != null) StartCoroutine(LoadMyAsyncScene());        
    }

    private void Update()
    {
        if (check_isInMenuArming == null) return;


        if(flag_load_started)
        {
            time_check += Time.deltaTime;
                       
            //Debug.Log(asyncOper.progress);
            if (time_check >= time_to_play && flag_played)
            {
                //SceneManager.LoadScene();
                asyncOper.allowSceneActivation = true;
                
            }           
        }
    }

    public void OnBtnWepClicked(int num)
    {      
        GameManager.instance.ChangeSet(num);
        for (int i = 0; i < btn_wep.Length; i++)
        {           
            btn_wep[i].ChangeImg(num);
            if (GameManager.instance.game_on == true) WeaponManager.instance.ReloadAmmo();
        }
        

    }


    

    public void StartGame()
    {
        flag_load_started = true;       
        
        vp = cinePlayer.gameObject.GetComponent<VideoPlayer>();
        time_to_play = vp.clip.length;
        Debug.Log(time_to_play);
        vp.Prepare();
        PlayerPrefs.SetInt("value_armset0", GameManager.instance.armset[0]);
        PlayerPrefs.SetInt("value_armset1", GameManager.instance.armset[1]);
              
        cinePlayer.gameObject.SetActive(true);
        playScreen.gameObject.SetActive(true);      
        vp.Play();
        
        flag_played = true; 

    }

    IEnumerator LoadMyAsyncScene()
    {
        // AsyncOperation을 통해 Scene Load 정도를 알 수 있다.
        asyncOper = SceneManager.LoadSceneAsync("Game_Lv1");
        asyncOper.allowSceneActivation = false;
        
        // Scene을 불러오는 것이 완료되면, AsyncOperation은 isDone 상태가 된다.
        while (!asyncOper.isDone)
        {
            yield return null;
        }
    }






}
