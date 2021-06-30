using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HeadToCamera : MonoBehaviour
{

    Transform pos_camera;


    // Start is called before the first frame update
    private void Update()
    {
        pos_camera = GameManager.instance.pos_of_camera;

        transform.LookAt(pos_camera);
    }


}
