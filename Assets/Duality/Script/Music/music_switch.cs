using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_switch : MonoBehaviour
{
    short musicsw = 1;


    void Start()
    {

        
        if ( musicsw ==1 )
        {

            FMOD.Studio.EventInstance lightmusicInstance;
            lightmusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Background/Background_music_light");
            lightmusicInstance.start();
            lightmusicInstance.release();


        }
        
        else
        {

            FMOD.Studio.EventInstance darkmusicInstance;
            darkmusicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Background/Background_music_dark");
            darkmusicInstance.start();
            darkmusicInstance.release();


        }
    }

}
