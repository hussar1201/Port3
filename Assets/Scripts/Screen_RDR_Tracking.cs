using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen_RDR_Tracking : MonoBehaviour
{

    public GameObject img_point_enemy;
    public GameObject pos_of_Camera;

    public Text text_SearchMode;

    public Transform EntriesRoot;

    private float interval_reset = 0.3f;
    private float time = 0f;
    private HashSet<int> set_ID = new HashSet<int>();


    private void Update()
    {
        time += Time.deltaTime;

        if (time >= interval_reset)
        {
            time = 0f;
            set_ID.Clear();
        }   
    }


    public void AcquiredTGT(List<RDR_TrackingInfo> list_frontTGT)
    {        

        for (int i = 0; i < list_frontTGT.Count; i++)
        {           

            if (!set_ID.Contains(list_frontTGT[i].id_tgt))
            {
          
                //if (list_frontTGT[i].pos.x > 300f || list_frontTGT[i].pos.x < -300f) return;

                set_ID.Add(list_frontTGT[i].id_tgt);
                GameObject tmp = Instantiate(img_point_enemy, list_frontTGT[i].pos, Quaternion.identity);                                
         
                WeaponManager.instance.target = list_frontTGT[i].tgt;         
                              
                tmp.transform.SetParent(EntriesRoot);
                
                tmp.transform.position = EntriesRoot.position + list_frontTGT[i].pos;
             

                Destroy(tmp, .4f);
            }
        }
    }

    public void ChangeTypeOfSearch()
    {

        RDRController.instance.ChangeTypeOfSearch();
        text_SearchMode.text = "SEARCH MODE : " + RDRController.instance.typesTGT[RDRController.instance.type_of_search];
    }


}


