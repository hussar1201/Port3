using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    public float move { get; private set; }

    public float rotate { get; private set; }
    public bool fire_gun { get; private set; }
    public bool fire_rocket { get; private set; }
    public bool fire_msl { get; private set; }
    public FixedJoystick joystick;
    public static string mode_input = "stick";
    private static PlayerInput m_instance;

    public static PlayerInput instance
    {
        get
        {       
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<PlayerInput>();
            }
            return m_instance;
        }
    }

    private void Awake()
    {
        
        if(instance !=this)
        {
            Destroy(gameObject);
            return;
        }

        move = 0f;
        rotate = 0f;
        fire_gun = false;
        fire_rocket = false;
        fire_msl = false;
    }

        
    void Update()
    {
      
        
        
        if (mode_input.Equals("stick"))
        {
            move = joystick.Vertical;
            rotate = joystick.Horizontal;
        }

        if (mode_input.Equals("keyboard"))
        {
            if(Input.GetKeyDown(KeyCode.E)) rotate = 1;
            if(Input.GetKeyDown(KeyCode.Q)) rotate = -1;
            move = Input.GetAxis("Vertical");
        }
        if (Input.GetKey(KeyCode.M)) fire_msl = true;
        if (Input.GetKey(KeyCode.G)) fire_gun = true;
        if (Input.GetKey(KeyCode.R)) fire_rocket = true;

    }


    public void OnPointerDownFireGun()
    {
       fire_gun = true;
    }

    public void OnPointerUPFireGun()
    {
        fire_gun = false;
    }

    public void OnPointerDownFireRocket()
    {
        fire_rocket = true;
    }

    public void OnPointerUPFireRocket()
    {
        fire_rocket = false;
    }

    public void OnPointerDownFireMSL()
    {
       fire_msl = true;
    }

    public void OnPointerUpFireMSL()
    {
        fire_msl = false;
    }



}
