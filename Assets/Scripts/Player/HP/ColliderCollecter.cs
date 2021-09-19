using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCollecter : MonoBehaviour
{
    public Collider[] arr_colliders;
    private PlayerHealth ph;
    private ContactPoint[] arr_cp;

    private void Start()
    {
        ph = GetComponentInParent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint cp = collision.GetContact(0);

        Collider c_this = cp.thisCollider;
        for (int i = 0; i < arr_colliders.Length; i++)
        {
            if (arr_colliders[i].Equals(c_this))
            {
                ph.OnPartDamaged(i);
            }

        }
    }

}


