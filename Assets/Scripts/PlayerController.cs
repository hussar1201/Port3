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
    public float speed = 70f;
    public float rotationSpeed = 1f;
    Rigidbody rb;
    private int HP = 100;
    float xInput, zInput, yInput;
    float move_slide_LR;

    float xRotation = 0.0f; // yaw ??????
    
    private const float LIMIT_DOWN = 3.2f;
    private const float LIMIT_UP = 45f;
    private const float LIMITER_ALT_SPEED_CHANGED = 10f;

    private float alt_calculated, move_LR_calculated;


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
        yInput = PlayerInput.instance.altitude;
        move_slide_LR = PlayerInput.instance.move_LR;
        xRotation += rotationSpeed * PlayerInput.instance.rotate;
                
        xInput = Input.GetAxis("Horizontal");
        rotation_Y = Quaternion.Euler(0f, xRotation, 0f);
        transform.rotation = rotation_Y;

        player_Huey.setPitch(zInput, xRotation);

        if (xInput == 0f) rb.velocity = (transform.forward * speed * zInput);
        else rb.velocity = (transform.forward * speed * zInput)
               + (transform.right * speed / 5 * xInput);

        if (xInput == 0f && zInput == 0) rb.velocity = new Vector3(0, 0, 0);


        alt_calculated = transform.position.y;
        move_LR_calculated = transform.position.x;

        if (yInput != 0)
        {
            alt_calculated = transform.position.y + (yInput/ LIMITER_ALT_SPEED_CHANGED);

            if (alt_calculated < LIMIT_DOWN) alt_calculated = LIMIT_DOWN + 0.1f;
            if (alt_calculated > LIMIT_UP) alt_calculated = LIMIT_UP - 0.1f;
        }

        if (move_slide_LR != 0)
        {
             move_LR_calculated = transform.position.x + (move_slide_LR / (LIMITER_ALT_SPEED_CHANGED*1.5f));           
        }

        transform.position = new Vector3(move_LR_calculated, alt_calculated, transform.position.z);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            SoundManager.instance.playOneShotAudio(SoundManager.sounds.warning,2);               
        }
    }




}
