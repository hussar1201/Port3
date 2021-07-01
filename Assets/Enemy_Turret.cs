using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    public Enemy_Nav enemy_Nav;
    private Vector3 enemy_pos_recalculated;
    public GameObject enemy_cannon;
    public GameObject Bullet;
    private Vector3 pos_bullet_start;


    private void Start()
    {
        pos_bullet_start = new Vector3(0, 0, 6.4f);
    }

    private void Update()
    {

        enemy_pos_recalculated = new Vector3(enemy_Nav.pc.transform.position.x, transform.position.y, enemy_Nav.pc.transform.position.z);
        transform.LookAt(enemy_pos_recalculated);
        enemy_cannon.transform.LookAt(enemy_Nav.pc.transform);       
    }


    public void Fire()
    {
        Instantiate(Bullet, transform.position + pos_bullet_start, Quaternion.identity);
    }

   
}


