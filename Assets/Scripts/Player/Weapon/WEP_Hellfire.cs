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

    private float time_interval_tracking = .5f;
    private float time_tracking = 0f;

    private Vector3 point_start;
    private Transform pos_pass;
    private bool flag_playsound = false;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider_explosion = GetComponent<Collider>();
        
        collider_explosion.enabled = false;
        ps = GetComponentInChildren<ParticleSystem>();
        ps.Play();
        ps.Pause();      
    }

    public void Fire(GameObject target)
    {
        this.target = target;
        
        pos_pass = WeaponManager.instance.pos_fall[0];
        transform.SetParent(GameManager.instance.transform);
        point_start = transform.position;
        fired = true;
        target_before = target.transform.position;
        ps.Play();

        rb.isKinematic = false;

    }

    void FixedUpdate()
    {
        if (!fired) return;
        time_after_launched += Time.deltaTime;
        time_tracking += Time.deltaTime;
        
        if (time_interval_tracking < time_tracking) 
        {
            point_start = transform.position;
            time_tracking = 0f;
        }          

        if (time_before_tracking > time_after_launched)
        {     
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }
        else 
        {                            
            collider_explosion.enabled = true;
            if (target != null)
            {
                Vector3 direction = target.transform.position - transform.position;
                direction.Normalize();
                Quaternion dirRotation = Quaternion.LookRotation(direction);
                rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, dirRotation, 120f * Time.deltaTime)); //test1
                rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime)); //Move Method 1                       
            }
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
