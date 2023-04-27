using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float masterListenerVolume;

    public static GameManager instance;

    void Awake()
    {
        // Make sure new scenes don't have any extra GameManagers since this one persists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Noting this out as Temporary measure for GameShowcaseBuild
        //DontDestroyOnLoad(gameObject);
    }

        // Start is called before the first frame update
    void Start()
    {
        masterListenerVolume = 1f;
    }

    public void SetMasterListenerVolume(float volume)
    {
        masterListenerVolume = volume;
    }

    public float GetMasterListenerVolume()
    {
        return masterListenerVolume;
    }
}
