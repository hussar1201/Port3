using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    public Enemy_Nav enemy_Nav;
    private Vector3 enemy_pos_recalculated;
    public GameObject enemy_cannon;
    public Shot_Enemy_Frag Bullet;
    public Transform pos_bullet_start;
    private Vector3 pos_tmp;

    private void Update()
    {
        enemy_pos_recalculated = new Vector3(enemy_Nav.pc.transform.position.x, transform.position.y, enemy_Nav.pc.transform.position.z);
        transform.LookAt(enemy_pos_recalculated);
        enemy_cannon.transform.LookAt(enemy_Nav.pc.transform);
        pos_tmp = enemy_Nav.pc.transform.position;
    }

    public void Fire()
    {
        Shot_Enemy_Frag tmp = Instantiate(Bullet, pos_bullet_start.position, Quaternion.identity);
        tmp.pos_for_explosion = pos_tmp;
    }  
}


