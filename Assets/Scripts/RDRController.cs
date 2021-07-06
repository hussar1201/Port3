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

    private RDR_TrackingInfo tgt_now;

    public RDR_Tracking[] rdr_Tracking;

    float interval_scan = 0.5f;
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
        tgt_now = new RDR_TrackingInfo();
    }


    public void ChangeTypeOfSearch()
    {        
        if (++type_of_search == typesTGT.Length) type_of_search = 0;
        target = null;
        target_before = null;
        WeaponManager.instance.ResetTGT();
        list_frontTGT.Clear();
    }

    // not yet....
    public void ChangeTarget()
    {      
        for (int i=0;i<list_frontTGT.Count;i++)
        {          
            if (list_frontTGT[i].id_tgt != tgt_now.id_tgt)
            {
                target = list_frontTGT[i].tgt;
            }
        }

    }


    private void Update()
    {
        time_scan += Time.deltaTime;
        if (time_scan >= interval_scan)
        {
            list_frontTGT.Clear();
            time_scan = 0f;
            rdr_Tracking[0].Search();                                   
            screen_RDR_Tracking.AcquiredTGT();

            if (list_frontTGT.Count != 0) { 
                target = list_frontTGT[0].tgt;
                tgt_now.id_tgt = list_frontTGT[0].id_tgt;
            }
            list_frontTGT.Clear();
        }
    }
}
