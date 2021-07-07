using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Indicator_HP_Status : MonoBehaviour
{
    private Indicator_Part_HP_Status[] arr_parts;

    // Start is called before the first frame update
    void Start()
    {

        arr_parts = GetComponentsInChildren<Indicator_Part_HP_Status>();

    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
