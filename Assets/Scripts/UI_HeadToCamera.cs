using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HeadToCamera : MonoBehaviour
{

    public int mode = 0;
    private Transform pos_camera;
    private Transform pos_camera_minimap;


    // Start is called before the first frame update
    private void Update()
    {
        pos_camera = GameManager.instance.pos_of_camera;
        pos_camera_minimap = GameManager.instance.pos_of_camera_minimap;

        transform.LookAt(pos_camera);
    }


}
