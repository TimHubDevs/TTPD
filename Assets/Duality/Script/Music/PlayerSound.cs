using UnityEngine;


public class PlayerSound : MonoBehaviour
{
    FMOD.Studio.EventInstance fsInstance;
    FMOD.Studio.EventInstance jumpInstance;

    void snd_footsteps()
        // ����� ����
    {
        fsInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps");
        fsInstance.start();
        fsInstance.release();
    }

    void snd_jump()
        // ������
    {
        jumpInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpUp");
        jumpInstance.start();
        jumpInstance.release();
    }

    void snd_jumpdwn()
        // �����������
    {
        FMOD.Studio.EventInstance jumpdwnInstance;

        jumpdwnInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/JumpDown");
        jumpdwnInstance.start();
        jumpdwnInstance.release();
    }

    void snd_punch()
        // �����
    {
        FMOD.Studio.EventInstance punchInstance;

        punchInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Punch");
        punchInstance.start();
        punchInstance.release();
    }

    void snd_damage_taken()
        // ���������� ����
    {
        FMOD.Studio.EventInstance damageInstance;

        damageInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Damage");
        damageInstance.start();
        damageInstance.release();
    }


    void snd_hide()
        // ����������, �������� =)
    {
        FMOD.Studio.EventInstance hideInstance;

        hideInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Helmet_drop");
        hideInstance.start();
        hideInstance.release();
    }

    void snd_unhide()
        // ������
        // =)
    {
        FMOD.Studio.EventInstance unhideInstance;

        unhideInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/unhide");
        unhideInstance.start();
        unhideInstance.release();
    }

    void snd_character_die()
        // ������ �������� ���������
    {
        FMOD.Studio.EventInstance character_dieInstance;

        character_dieInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Die");
        character_dieInstance.start();
        character_dieInstance.release();
    }

    void snd_electric_bolt()
        // ������ �������������� �������
    {
        FMOD.Studio.EventInstance ebInstance;

        ebInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Electric_bolt");
        ebInstance.start();
        ebInstance.release();
    }

    void snd_helmet_drop_die()
        // ���� ������ ��� ������
    {
        FMOD.Studio.EventInstance hddieInstance;

        hddieInstance = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Helmetdropdie");
        hddieInstance.start();
        hddieInstance.release();
    }
}