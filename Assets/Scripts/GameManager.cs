using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public bool game_on = true;
    public int[] armset;

    private bool m_gameover = true;
    public bool gameover
    {
        get;
        private set;
    }

    public Transform pos_of_camera;

    public static GameManager instance
    {
        get
        {
            if(m_instance==null)
            {
                m_instance = FindObjectOfType<GameManager>();
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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
