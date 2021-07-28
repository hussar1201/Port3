using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_rocketpack : MonoBehaviour, Projectilepack
{
    public static int size_pack = 64;
    public Transform[] pos_of_packs;
    private Vector3 pos_respawn_rocket = new Vector3(0, 0, 1.5f);
    public WEP_Rocket prefab;
    private bool flag_left = true;

    public bool Fire(GameObject target)
    {
        
        int i = 0;

        if (flag_left == true) i = 0;
        else i = 1;
        flag_left = !flag_left;

        WEP_Rocket tmp = Instantiate(prefab, pos_of_packs[i].position, Quaternion.identity);
        tmp.flag_left = flag_left;

        tmp.transform.LookAt(WeaponManager.instance.pos_fall[2]);

        return true;
    }



}
