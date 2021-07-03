using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDR_Tracking : MonoBehaviour
{
    public LayerMask lm;
        
    //private List<RDR_TrackingInfo> list_frontTGT = new List<RDR_TrackingInfo>();
    //private HeliController heliCon;

    private Screen_RDR_Tracking screen_RDR_Tracking;
    Collider[] hitColliders;

    int cnt = 0;

    private float size_of_x;     
    public float rate_b = 1.2f;

    float interval_scan = 0.3f;
    float time_scan = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //???????? ?????? ???? ???? ????
        lm = LayerMask.GetMask(RDRController.instance.typesTGT[RDRController.instance.type_of_search]);

        screen_RDR_Tracking = FindObjectOfType<Screen_RDR_Tracking>();
        
        hitColliders =
           Physics.OverlapBox(gameObject.transform.position,
           gameObject.transform.localScale/2, Quaternion.identity, lm);

        size_of_x = GetComponent<Collider>().transform.localScale.x;

        cnt = hitColliders.Length;
    }

    // Update is called once per frame  
    void Update()
    {
        lm = LayerMask.GetMask(RDRController.instance.typesTGT[RDRController.instance.type_of_search]);
        
        time_scan += Time.deltaTime;

        if (time_scan >= interval_scan)
        {

            hitColliders =
                Physics.OverlapBox(gameObject.transform.position,
                gameObject.transform.localScale / 2, Quaternion.identity, lm);

            if (cnt != hitColliders.Length) cnt = hitColliders.Length;


            for (int i = 0; i < hitColliders.Length; i++)
            {
                // UI ???? ???? ??????(x??) ??????                             

                if (  (-size_of_x) < hitColliders[i].transform.position.x && hitColliders[i].transform.position.x < (size_of_x))
                {
                    float x = (hitColliders[i].transform.position.x - transform.position.x);
                    float y = (hitColliders[i].transform.position.y - transform.position.y);

                    RDR_TrackingInfo tgt = new RDR_TrackingInfo();
                    tgt.tgt = hitColliders[i].gameObject;

                    tgt.id_tgt = hitColliders[i].GetInstanceID();

                    tgt.pos = new Vector3(x * rate_b, y + 7f, 0f);

                    RDRController.instance.list_frontTGT.Add(tgt);                   
                }
            }               

            time_scan = 0f;          
        }
    }

}

