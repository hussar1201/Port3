using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDR_Tracking : MonoBehaviour
{
    public LayerMask lm;

    //private List<RDR_TrackingInfo> list_frontTGT = new List<RDR_TrackingInfo>();
    //private HeliController heliCon;

    Collider[] hitColliders;

    int cnt = 0;

    private float size_of_x;
    public float rate_b = 1.2f;

    float interval_scan = 0.3f;
    float time_scan = 0f;

    // Start is called before the first frame update
    void Start()
    {
        size_of_x = GetComponent<Collider>().transform.localScale.x;
    }


    public void Search()
    {
        lm = LayerMask.GetMask(RDRController.instance.typesTGT[RDRController.instance.type_of_search]);

        hitColliders =
            Physics.OverlapBox(gameObject.transform.position,
            gameObject.transform.localScale / 2, Quaternion.identity, lm);

        if (cnt != hitColliders.Length) cnt = hitColliders.Length;

        Debug.Log(cnt);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            // UI ???? ???? ??????(x??) ??????                             
            
            Vector3 pos_heli = WeaponManager.instance.transform.position;
            Vector3 res = hitColliders[i].transform.position - pos_heli;
            
            RDR_TrackingInfo tgt = new RDR_TrackingInfo();
            tgt.tgt = hitColliders[i].gameObject;

            tgt.id_tgt = hitColliders[i].GetInstanceID();

            tgt.pos = new Vector3(res.x, 20f, 0f);

            RDRController.instance.list_frontTGT.Add(tgt);
        }



    }



}

