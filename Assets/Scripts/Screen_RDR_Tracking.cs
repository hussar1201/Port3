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


    public void AcquiredTGT()
    {
        int cnt_tmp = 0;
       

        for (int i = 0; i < RDRController.instance.list_frontTGT.Count; i++)
        {                     

            if (!set_ID.Contains(RDRController.instance.list_frontTGT[i].id_tgt))
            {
                Debug.Log(RDRController.instance.list_frontTGT[i].id_tgt);
                Debug.Log(RDRController.instance.list_frontTGT[i].pos);
                //if (list_frontTGT[i].pos.x > 300f || list_frontTGT[i].pos.x < -300f) return;

                set_ID.Add(RDRController.instance.list_frontTGT[i].id_tgt);
                GameObject tmp = tmp = Instantiate(img_point_enemy, transform.position, Quaternion.identity);
                tmp.transform.position = EntriesRoot.position + RDRController.instance.list_frontTGT[i].pos;
                tmp.transform.SetParent(EntriesRoot);

                RDRController.instance.target = RDRController.instance.list_frontTGT[i].tgt;                            
                
              
                Destroy(tmp, .4f);

              

            }
        }
    

    }


    public void ChangeTypeOfSearch()
    {
        RDRController.instance.ChangeTypeOfSearch();
        text_SearchMode.text = "[SEARCH MODE] " + RDRController.instance.typesTGT[RDRController.instance.type_of_search];
        RDRController.instance.target = null;
        RDRController.instance.target_before = null;
        set_ID.Clear();
    }


}


