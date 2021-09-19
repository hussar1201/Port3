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
        //���õ� ������ ���� Ž���ǵ��� ���̾ ����
        lm = LayerMask.GetMask(RDRController.instance.typesTGT[RDRController.instance.type_of_search]);
        Vector2 rdr_to_heli = new Vector2(0f, 0f); // 2���� UI�� ǥ���ϱ� ���� 2���� ����
        Vector2 tgt_to_heli = new Vector2(0f, 0f);
        hitColliders = Physics.OverlapBox(gameObject.transform.position,
                       gameObject.transform.localScale / 2, Quaternion.identity, lm);

        if (cnt != hitColliders.Length) cnt = hitColliders.Length;

        for (int i = 0; i < hitColliders.Length; i++)
        {
            Vector3 pos_heli = WeaponManager.instance.transform.position;

            //�÷��̾� ��ġ���� Ž������ �߰���ġ�� ���ϴ� ���Ͱ� ����
            Vector3 tmp_rdr_to_heli = transform.position - pos_heli;
            //�÷��̾� ��ġ���� Ž���� �� ��ġ�� ���ϴ� ���Ͱ� ����
            Vector3 tmp_tgt_to_heli = hitColliders[i].transform.position - pos_heli;

            //3���� ��ǥ�� 2����ȭ
            rdr_to_heli.x = tmp_rdr_to_heli.x;
            rdr_to_heli.y = tmp_rdr_to_heli.z;
            tgt_to_heli.x = tmp_tgt_to_heli.x;
            tgt_to_heli.y = tmp_tgt_to_heli.z;

            //�÷��̾� ������ �������� �Ͽ� ������ ������ ���� ��
            //�ش� ������ �°� ���̴� UI ȭ�鿡 ǥ��
            float angle = Vector2.SignedAngle(tgt_to_heli, rdr_to_heli);
            RDR_TrackingInfo tgt = new RDR_TrackingInfo();
            tgt.tgt = hitColliders[i].gameObject;
            tgt.id_tgt = hitColliders[i].GetInstanceID();
            tgt.pos = new Vector3(angle * 6.6f, 20f, 0f);
            RDRController.instance.list_frontTGT.Add(tgt);
        }
    }

}

