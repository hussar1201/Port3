using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Cannon : MonoBehaviour
{
    public Transform gunPoint;
    public Bullet_cannon bullet;
    public GameObject effect;


    public void Fire()
    {
        Transform tmp = Instantiate(bullet, gunPoint.position, Quaternion.identity).transform;
        tmp.LookAt(WeaponManager.instance.pos_fall[0]);
        SoundManager.instance.playOneShotAudio(SoundManager.sounds.cannon_30mm);
        //effect.SetActive();
        
    }

}
