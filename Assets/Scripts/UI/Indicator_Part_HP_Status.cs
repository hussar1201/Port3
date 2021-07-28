using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Indicator_Part_HP_Status : MonoBehaviour
{
    private RawImage part;
    float[] color_HSV_default = {0.3f, 0.8f, 0.8f, 0.3f};
    Color color_original;
    Color color_present;

    float time = 0f;
    float time_x = .5f;

    Color col;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<RawImage>();
        color_original = Color.HSVToRGB(color_HSV_default[0], color_HSV_default[1], color_HSV_default[2]);
        color_original.a = 0.3f;
        color_present = color_original;               
    }

    /*--TEST CODE--
    void Update()
    {     
        time += Time.deltaTime;
        if (time_x <= time && color_HSV_default[0]>=0f)
        {
            time = 0f;
            color_present = Color.HSVToRGB(color_HSV_default[0]-=0.01f, color_HSV_default[1] += 0.01f, color_HSV_default[2]);
            color_present.a = 0.3f;
            part.color = color_present;
        }
    }
    */

    public void ChangeColor()
    {
        color_present = Color.HSVToRGB(color_HSV_default[0] -= 0.03f, color_HSV_default[1] += 0.03f, color_HSV_default[2]);
        color_present.a = 0.3f;
        part.color = color_present;
    }




}
