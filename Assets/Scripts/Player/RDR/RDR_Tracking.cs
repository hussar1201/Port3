using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDR_Tracking : MonoBehaviour
{
    public LayerMask lm;

    private Collider[] hitColliders;
    private int cnt = 0;

    public void Search()
    {
        //선택된 종류의 적만 탐색되도록 레이어값 설정
        lm = LayerMask.GetMask(RDRController.instance.typesTGT[RDRController.instance.type_of_search]);
        Vector2 rdr_to_heli = new Vector2(0f, 0f); // 2차원 UI에 표시하기 위한 2차원 벡터
        Vector2 tgt_to_heli = new Vector2(0f, 0f);
        hitColliders = Physics.OverlapBox(gameObject.transform.position,
                       gameObject.transform.localScale / 2, Quaternion.identity, lm);

        if (cnt != hitColliders.Length) cnt = hitColliders.Length;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Vector3 pos_heli = WeaponManager.instance.transform.position;

            //플레이어 위치에서 탐색범위 중간위치로 향하는 벡터값 산출
            Vector3 tmp_rdr_to_heli = transform.position - pos_heli;
            //플레이어 위치에서 탐색된 적 위치로 향하는 벡터값 산출
            Vector3 tmp_tgt_to_heli = hitColliders[i].transform.position - pos_heli;

            //3차원 좌표를 2차원화
            rdr_to_heli.x = tmp_rdr_to_heli.x;
            rdr_to_heli.y = tmp_rdr_to_heli.z;
            tgt_to_heli.x = tmp_tgt_to_heli.x;
            tgt_to_heli.y = tmp_tgt_to_heli.z;

            //플레이어 정면을 기준으로 하여 적과의 각도를 구한 후
            //해당 각도에 맞게 레이더 UI 화면에 표시
            float angle = Vector2.SignedAngle(tgt_to_heli, rdr_to_heli);
            RDR_TrackingInfo tgt = new RDR_TrackingInfo();
            tgt.tgt = hitColliders[i].gameObject;
            tgt.id_tgt = hitColliders[i].GetInstanceID();
            tgt.pos = new Vector3(angle * 6.6f, 20f, 0f);
            RDRController.instance.list_frontTGT.Add(tgt);
        }
    }

}

