using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Turret : MonoBehaviour
{
    public Enemy_Nav enemy_Nav;
    private Vector3 enemy_pos_recalculated;
    public GameObject enemy_cannon;


    
    private void Update()
    {

        enemy_pos_recalculated = new Vector3(enemy_Nav.pc.transform.position.x, transform.position.y, enemy_Nav.pc.transform.position.z);
        transform.LookAt(enemy_pos_recalculated);
        enemy_cannon.transform.LookAt(enemy_Nav.pc.transform);
        ;
    }
   
}


