using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDRController : MonoBehaviour
{
    private static RDRController m_instance;

    public string[] typesTGT = {"AAA", "TANK", "APC"};
    public int type_of_search = 0;



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



    public void ChangeTypeOfSearch()
    {
         
        if (++type_of_search == typesTGT.Length) type_of_search = 0;
        Debug.Log(typesTGT[type_of_search]);
          

    }


}
