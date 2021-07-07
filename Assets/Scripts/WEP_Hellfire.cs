using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Hellfire : MonoBehaviour
{

    float speed = 150f;
    private Rigidbody rb;

    private ParticleSystem ps;

    private bool fired = false;
    private GameObject target;
    private Vector3 target_before;
    private Collider collider_explosion;

    private float time_before_tracking = .2f;
    private float time_after_launched = 0f;
    private Vector3 point_start;
    private Transform pos_pass;
    private bool flag_playsound = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider_explosion = GetComponent<Collider>();
        pos_pass = WeaponManager.instance.pos_fall[0];
        collider_explosion.enabled = false;
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Play();
        ps.Pause();      
    }

    public void Fire(GameObject target)
    {
        this.target = target;
               
        transform.SetParent(GameManager.instance.transform);
        point_start = transform.position;
        fired = true;
        target_before = target.transform.position;
        ps.Play();

    }

    void Update()
    {
        if (!fired) return;
        time_after_launched += Time.deltaTime;
        //StartCoroutine(Startflash());



        if (time_before_tracking > time_after_launched)
        {
            rb.MovePosition(transform.position + 
                Vector3.MoveTowards(transform.position, target.transform.position, speed).normalized * Time.deltaTime);
                        
            //rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
        }
        else if (time_before_tracking <= time_after_launched)
        {
            //rb.isKinematic = false;
            Vector3 heading, los;
            collider_explosion.enabled = true;
            if (target != null)
            {
                heading = target.transform.position + new Vector3(0f, 1f, 0f);
                los = heading - transform.position;
                transform.LookAt(target.transform);
                target_before = target.transform.position;
            }
            else
            {
                heading = target_before;
                los = heading - transform.position;
                transform.LookAt(heading);
                Destroy(gameObject, 0.5f);
            }

            rb.MovePosition(transform.position + los.normalized * speed * Time.deltaTime);

        }

    }

    
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ps.Stop();
            if (!flag_playsound) 
            {
                flag_playsound = true;
                SoundManager.instance.playOneShotAudio(SoundManager.sounds.tgtdestroyed, 2);
            }
            
            Destroy(gameObject, 0.3f);
        }

    }

}
