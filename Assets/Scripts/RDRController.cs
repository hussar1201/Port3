using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDRController : MonoBehaviour
{
    private static RDRController m_instance;
    public GameObject target;
    public GameObject target_before;

    public string[] typesTGT = {"AAA", "TANK", "APC"};
    public int type_of_search = 0;
    public List<RDR_TrackingInfo> list_frontTGT = new List<RDR_TrackingInfo>();
    public Screen_RDR_Tracking screen_RDR_Tracking;

    public RDR_Tracking[] arr_RDR_Tracking;

    float interval_scan = 0.4f;
    float time_scan = 0f;



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
        target = null;
        target_before = null;
        WeaponManager.instance.ResetTGT();
        list_frontTGT.Clear();
    }


    private void Update()
    {
        time_scan += Time.deltaTime;
        if (time_scan >= interval_scan)
        {
            for(int i = 0; i<arr_RDR_Tracking.Length;i++)
            {
                arr_RDR_Tracking[i].Search();               
            }                      

            screen_RDR_Tracking.AcquiredTGT();
            time_scan = 0f;
            list_frontTGT.Clear();
        }
    }
}
