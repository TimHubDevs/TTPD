using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_sound : MonoBehaviour
{
    
    
    FMOD.Studio.EventInstance fsInstance;
    FMOD.Studio.EventInstance jumpInstance;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Footsteps()
    {

        fsInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        fsInstance.start();
        fsInstance.release();

    }

    void snd_jump()
    {

        jumpInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpUp");
        jumpInstance.start();
        jumpInstance.release();

    }

    void snd_jumpdwn()
    {
        
        FMOD.Studio.EventInstance jumpdwnInstance;

        jumpdwnInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpDown");
        jumpdwnInstance.start();
        jumpdwnInstance.release();

    }
}
