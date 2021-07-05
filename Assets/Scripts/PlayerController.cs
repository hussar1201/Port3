/* ?? ?????????? Player?? ???? ?????????? Heli?? ??????????, 
 * RigidBody ???????? ???????? Y?? ???? ?????? ???????? ????
 * ???? ?????? Y?? ?????? ???????????? ???????? ?????? ????
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    HeliController player_Huey; // ???? ?????????? ???????? ?????????? ????
    public float speed = 50f;
    public float rotationSpeed = 1f;
    Rigidbody rb;
    private int HP = 100;
    float xInput, zInput;
    float xRotation = 0.0f; // yaw ??????
    int direction_y = 1;


    // Start is called before the first frame update
    void Start()
    {   
        player_Huey = GetComponentInChildren<HeliController>(); //???????? ?? ???? ???????? ????.
        rb = GetComponent<Rigidbody>(); //Player?? rb(??????)
    }

    public int getHP()
    {
        return HP;
    }

    void Die()
    {
       // GameManager.GameOver = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += new Vector3(0f, .01f, 0f) * direction_y;
        //direction_y *= -1;
        Quaternion rotation_Y;

        //zInput = Input.GetAxis("Vertical");

        zInput = PlayerInput.instance.move;
        xRotation += rotationSpeed * PlayerInput.instance.rotate;
        
        xInput = Input.GetAxis("Horizontal");
        rotation_Y = Quaternion.Euler(0f, xRotation, 0f);
        transform.rotation = rotation_Y;

        player_Huey.setPitch(zInput, xRotation);

        if (xInput == 0f) rb.velocity = (transform.forward * speed * zInput);
        else rb.velocity = (transform.forward * speed * zInput) + (transform.right * speed / 5 * xInput);

        if (xInput == 0f && zInput == 0) rb.velocity = new Vector3(0, 0, 0);


        // !!!TEST!!! Changing Altitude

        float tmp = UIManager.instance.slider_altitude.value - transform.position.y;

        rb.MovePosition(transform.position + new Vector3(0, tmp, 0));        
        

    }

}
