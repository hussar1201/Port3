using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_Enemy_Frag : MonoBehaviour
{
    public Vector3 pos_for_explosion;
    public float speed = 100f;
    Collider collider_explosion;
    Vector3 direction_heading;
    Vector3 pos_CEP;
    Rigidbody rb;
    ParticleSystem ps;
    MeshRenderer ms;

    void Start()
    {
        collider_explosion = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<MeshRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        collider_explosion.enabled = false;
        pos_CEP = new Vector3(Random.Range(0.1f, .2f), Random.Range(0.1f, .2f), Random.Range(0.1f, .2f));
        pos_for_explosion += pos_CEP;
        transform.LookAt(pos_for_explosion);
    }

    void Update()
    {
        direction_heading = pos_for_explosion - transform.position;

        if (Mathf.Abs(direction_heading.x) < pos_CEP.x || Mathf.Abs(direction_heading.y) < pos_CEP.y || Mathf.Abs(direction_heading.z) < pos_CEP.z)
        {
            ms.enabled = false;
            collider_explosion.enabled = true;
            if (ps != null) ps.Play();
            Destroy(gameObject, .2f);
        }
        else
        {
            transform.position += direction_heading.normalized * speed * Time.deltaTime;
        }
    }
}
