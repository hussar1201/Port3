using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public bool game_on = true;
    public int[] armset;

    private bool m_gameover = true;
    public bool flag_supply = false;

    public bool gameover
    {
        get;
        private set;
    }

    public Transform pos_of_camera;
    public Transform pos_of_camera_minimap;

    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
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
        
        ChopperManager tmp = FindObjectOfType<ChopperManager>();
        if (tmp == null)
        {
            game_on = true;
            if (PlayerPrefs.HasKey("value_armset0")) armset[0] = PlayerPrefs.GetInt("value_armset0");
            if (PlayerPrefs.HasKey("value_armset1")) armset[1] = PlayerPrefs.GetInt("value_armset1");
        }
        else
        {
            PlayerPrefs.DeleteAll();
            armset[0] = 0;
            armset[1] = 1;
        }        
        
    }

    public void ChangeSet(int num)
    {
        WeaponManager.instance.ChangeSet(num);               
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
