using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{

    private const float speed_normal = 1000f;
    private float speed;
    private float speed_before;
    public int mode_rotate;
    
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed_normal;

        if (mode_rotate == 0) rotation = Vector3.left;
        if (mode_rotate == 1) rotation = Vector3.up;

    }

    // Update is called once per frame
    void Update()
    {
        speed = speed_normal * (1 + Mathf.Abs(PlayerInput.instance.move));
        if (mode_rotate == 0)
        {
            
            if (Mathf.Abs(PlayerInput.instance.move) < .5)
            {
                if (speed_before > .5) SoundManager.instance.StopPlay(); 
                else
                {
                    if(!SoundManager.instance.isPlaying()) SoundManager.instance.playOneShotAudio(SoundManager.sounds.rotor_lowpower,1);
                }              
            }
            else
            {
                if (speed_before <= .5) SoundManager.instance.StopPlay();
                else
                {
                    if (!SoundManager.instance.isPlaying()) SoundManager.instance.playOneShotAudio(SoundManager.sounds.rotor_highpower, 1);
                }                            
            }
        }
        //speed_before = speed;

        speed_before = Mathf.Abs(PlayerInput.instance.move);

        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}

