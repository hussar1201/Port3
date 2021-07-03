using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Hellfire : MonoBehaviour
{

    float speed = 100f;
    private Rigidbody rb;

    private ParticleSystem ps;

    private bool fired = false;
    private GameObject target;
    private float time_before_tracking = .2f;
    private float time_after_launched = 0f;
    private Vector3 point_start;
    private bool tgt_set;
    public GameObject[] arr_Muzzle;
    private Transform pos_pass;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        tgt_set = false;
        pos_pass = WeaponManager.instance.pos_fall[0];

        /*
        ps = GetComponentInChildren<ParticleSystem>();
         ps.Play();
        ps.Pause();
        */
    }

    public void Fire(GameObject target)
    {
        this.target = target;

        transform.SetParent(GameManager.instance.transform);
        fired = true;

        for (int i = 0; i < arr_Muzzle.Length; i++) arr_Muzzle[i].SetActive(true);


        //ps.Play();


    }

    void Update()
    {
        if (!fired) return;

        time_after_launched += Time.deltaTime;
        //StartCoroutine(Startflash());

        

        if (time_before_tracking > time_after_launched)
        {

            rb.MovePosition(transform.position + Vector3.forward * speed * Time.deltaTime);
        }
        else if (time_before_tracking <= time_after_launched)
        {

            transform.LookAt(target.transform);

            Vector3 heading = target.transform.position + new Vector3(0f, 1f, 0f);
            Vector3 los = heading - transform.position;

            rb.MovePosition(transform.position + los.normalized * speed * Time.deltaTime);                       
            
        }

    }

    /*
    IEnumerator Startflash()
    {
        const float INTERVAL = 0.03f;
        for (int i = 0; i < arr_Muzzle.Length - 1; i++)
        {
            arr_Muzzle[i].SetActive(true);
            arr_Muzzle[i + 1].SetActive(true);
            yield return new WaitForSeconds(INTERVAL);
            arr_Muzzle[i].SetActive(false);
            arr_Muzzle[i + 1].SetActive(false);
            yield return new WaitForSeconds(INTERVAL);
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        //ps.Stop();

        for (int i = 0; i < arr_Muzzle.Length; i++) arr_Muzzle[i].SetActive(false);

        Destroy(gameObject, 0.2f);
        Destroy(collision.gameObject, 0.2f);
    }



}
