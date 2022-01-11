using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TriggerTeleport : MonoBehaviour
{
    bool startFade = false;
    public int fadeTimer = 2;
    public Transform Player;
    public Transform TargetLocation;
    public bool activateTeleport;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (activateTeleport)
        {
            activateTeleport = false;
            startFade = !startFade;

            if (startFade)
            {
                SteamVR_Fade.Start(Color.clear, 0);
                SteamVR_Fade.Start(Color.black, fadeTimer);
                StartCoroutine(teleportPlayer(fadeTimer));
            }
            else
            {
                SteamVR_Fade.Start(Color.black, 0);
                SteamVR_Fade.Start(Color.clear, fadeTimer);
            }
           
        }
    }

    IEnumerator teleportPlayer(float s)
    {
        yield return new WaitForSecondsRealtime(s);
        Player.position = TargetLocation.position;
        Player.eulerAngles = TargetLocation.eulerAngles;
    }
}
