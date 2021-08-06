using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMover : MonoBehaviour
{

    public LayerMask lm;
    private RaycastHit hitPoint;
    public GameObject aim;
    private Vector3 vc = new Vector3(0f, .5f, -5f);


    // Update is called once per frame
    void FixedUpdate()
    {

        bool res = Physics.Raycast(transform.position, transform.forward, out hitPoint, 100f, lm);

        if (res) aim.transform.position = hitPoint.point + vc;
        else
        {
            bool res2 = Physics.Raycast(transform.position+(transform.forward*100), transform.up * -1, out RaycastHit hp2, 100f, lm);
            if (res2) aim.transform.position = hp2.point + vc;
        }



    }
}
