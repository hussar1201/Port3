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
    private const float LIMIT_UP = 40f;
    private const float LIMITER_ALT_SPEED_CHANGED = 2f;

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
        
        Quaternion rotation_X;

        zInput = PlayerInput.instance.move;
        yInput = PlayerInput.instance.altitude;
        move_slide_LR = PlayerInput.instance.move_LR;
        xRotation += rotationSpeed * PlayerInput.instance.rotate;
                
        xInput = Input.GetAxis("Horizontal");

        if (xRotation != 0f)
        {
            rotation_X = Quaternion.Euler(0f, xRotation, 0f);
            transform.rotation = rotation_X;
        }
             
        Vector3 speed_current = new Vector3(0, 0, 0);

        if (zInput != 0f) speed_current +=(transform.forward * speed * zInput);
        if (yInput != 0f)
        {

            if (transform.position.y > LIMIT_UP) 
                transform.position = new Vector3(transform.position.x,LIMIT_UP, transform.position.z);
            else
                speed_current += (transform.up * speed * (yInput / LIMITER_ALT_SPEED_CHANGED));           

        }
            

        if (move_slide_LR != 0f) 
            speed_current += (transform.right * speed * (move_slide_LR / (LIMITER_ALT_SPEED_CHANGED * 1.5f)));

        player_Huey.setPitch(zInput, xRotation);
        rb.velocity = speed_current;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy_Bullet"))
        {
            SoundManager.instance.playOneShotAudio(SoundManager.sounds.warning,2);               
        }
    }




}
