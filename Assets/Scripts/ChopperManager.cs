using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperManager : MonoBehaviour
{
    public GameObject[] arr_choppers;
    private int cnt_chopper;

    // Start is called before the first frame update
    void Start()
    {
        cnt_chopper = 0;            
    }
    
    // Update is called once per frame
    void Update()
    {
                
    }


    public void click_left() => changeChopper(0);
    public void click_right() => changeChopper(1);

    public void changeChopper(int x)
    {

        if(x==1) if(++cnt_chopper==arr_choppers.Length) cnt_chopper=0;
        if(x==0) if (--cnt_chopper == -1) cnt_chopper = arr_choppers.Length-1;

        for (int i = 0; i < arr_choppers.Length; i++)
        {
            if (i == cnt_chopper)
            {
                arr_choppers[i].SetActive(true);
                continue;
            }
            arr_choppers[i].SetActive(false);            
        }           
    }

}
