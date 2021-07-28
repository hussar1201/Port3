using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineController : MonoBehaviour
{

    public PlayableDirector pd;
    public TimelineAsset tla;

    // Start is called before the first frame update
    public void Play()
    {
        pd.Play();
            
    }

     public void PlayfromTimeline()
    {
        pd.Play(tla);
    }

}
