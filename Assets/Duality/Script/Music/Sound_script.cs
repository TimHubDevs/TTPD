using UnityEngine;

public class Sound_script : MonoBehaviour
{
    void snd_explosion_idle()
        // БОмба ловушка паук Idle
    {
        FMOD.Studio.EventInstance sndInstance1;
        sndInstance1 = FMODUnity.RuntimeManager.CreateInstance("event:/Explosive/Explosive_idle");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance1, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance1.start();
        sndInstance1.release();

    }

    void snd_explosion_bad()
    // БОмба ловушка паук взрыв
    {

        FMOD.Studio.EventInstance sndInstance2;
        sndInstance2 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Explosive/Explosive_bad");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance2, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance2.start();
        sndInstance2.release();
    }

    void snd_explosion_heal()
    // БОмба ловушка паук лечение
    {

        FMOD.Studio.EventInstance sndInstance3;
        sndInstance3 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Explosive/Explosive_good");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance3, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance3.start();
        sndInstance3.release();
    }

    void snd_explosion_die()
    // БОмба ловушка паук смерть
    {

        FMOD.Studio.EventInstance sndInstance4;
        sndInstance4 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Explosive/Explosive_die");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance4, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance4.start();
        sndInstance4.release();
    }

    void snd_boar_idle()
    // Кабан Idle
    {

        FMOD.Studio.EventInstance sndInstance5;
        sndInstance5 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Boar/Boar_bad");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance5, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance5.start();
        sndInstance5.release();
    }

    void snd_boar_footsteps()
    // Кабан шаги
    {

        FMOD.Studio.EventInstance sndInstance6;
        sndInstance6 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Boar/Boar_footsteps");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance6, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance6.start();
        sndInstance6.release();
    }

   

    void snd_boar_good()
    // Кабан хорошее действее , дает рывок ?
    {

        FMOD.Studio.EventInstance sndInstance8;
        sndInstance8 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Boar/Boar_good");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance8, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance8.start();
        sndInstance8.release();
    }


    void snd_boar_die()
    // Кабан хорошее действее , дает рывок ?
    {

        FMOD.Studio.EventInstance sndInstance9;
        sndInstance9 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Boar/Boar_die");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance9, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance9.start();
        sndInstance9.release();
    }


    void snd_trap_bad()
    // ловушка дерево, наносит урон
    {

        FMOD.Studio.EventInstance sndInstance10;
        sndInstance10 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Trap/Trap_bad");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance10, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance10.start();
        sndInstance10.release();
    }

    void snd_trap_good()
    // ловушка дерево, даёт броню? позитивное действие
    {

        FMOD.Studio.EventInstance sndInstance11;
        sndInstance11 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Trap/Trap_good");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance11, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance11.start();
        sndInstance11.release();
    }

    void snd_spring_bad_ground()
    // ловушка попрыгун, приземление
    {

        FMOD.Studio.EventInstance sndInstance12;
        sndInstance12 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Spring/Spring_bad_ground");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance12, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance12.start();
        sndInstance12.release();
    }

    void snd_spring_bad_start()
    // ловушка попрыгун, начало прыжка
    {

        FMOD.Studio.EventInstance sndInstance14;
        sndInstance14 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Spring/Spring_bad_start");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance14, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance14.start();
        sndInstance14.release();
    }

    void snd_spring_good()
    // ловушка попрыгун, позитивный звук
    {

        FMOD.Studio.EventInstance sndInstance15;
        sndInstance15 = FMODUnity.RuntimeManager.CreateInstance("event:/Mobs/Spring/Spring_good");
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sndInstance15, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sndInstance15.start();
        sndInstance15.release();
    }


}
