using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChopperManager : MonoBehaviour
{
    public RawImage img_clipboard;
    public Image err_img1;
    public RawImage err_img2;
    public Text name_chopper;
    private string[] arr_name_chopper = { "AH-64A", "AH-6", "UH-60" };

    public GameObject[] arr_choppers;
    private int cnt_chopper;

    // Start is called before the first frame update
    void Start()
    {
        cnt_chopper = 0;            
    }

    public void click_left() => changeChopper(0);
    public void click_right() => changeChopper(1);

    public void changeChopper(int x)
    {
        if(x==1) if(++cnt_chopper==arr_choppers.Length) cnt_chopper=0;
        if(x==0) if((--cnt_chopper) == -1) cnt_chopper = arr_choppers.Length-1;

        Debug.Log("Clicked");

        for (int i = 0; i < arr_choppers.Length; i++)
        {
            if (i == cnt_chopper)
            {              
                arr_choppers[i].SetActive(true);
                name_chopper.text = arr_name_chopper[i];
                continue;
            }

            arr_choppers[i].SetActive(false);

            if (cnt_chopper == 0)
            {
                img_clipboard.gameObject.SetActive(true);
                err_img1.gameObject.SetActive(false);
                err_img2.gameObject.SetActive(false);
            }
            else
            {
                img_clipboard.gameObject.SetActive(false);
                err_img1.gameObject.SetActive(true);
                err_img2.gameObject.SetActive(true);
            }
        }

    }




}
