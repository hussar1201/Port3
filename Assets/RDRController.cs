using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDRController : MonoBehaviour
{
    private static RDRController m_instance;

    public int type_of_search = 2;


    public static RDRController instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<RDRController>();
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

}
