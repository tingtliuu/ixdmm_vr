using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TriggerTeleport : MonoBehaviour
{
    bool startFade = false;
    public int fadeTimer = 2;
    private GameObject Player;
    [SerializeField] Transform PlayerTargetLocation;
    [SerializeField] Transform PlayerDoll;
    [SerializeField] Transform DollTargetLocation;
    [SerializeField] GameObject PlayerBody;
    private List<GameObject> Head = new List<GameObject>();
    private List<GameObject> Arms = new List<GameObject>();

    public bool activateTeleport;

    private void Start()
    {
        Player = GetComponent<GameManager>().Player;
        FindObjectwithTag("DollArm", Arms);
        FindObjectwithTag("DollHead", Head);
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
        Player.transform.position = PlayerTargetLocation.position;
        Player.transform.eulerAngles = PlayerTargetLocation.eulerAngles;
        PlayerDoll.position = DollTargetLocation.position;
        PlayerDoll.eulerAngles = (DollTargetLocation.eulerAngles + new Vector3(0,90,0));
        PlayerDoll.parent = DollTargetLocation;

        if(Head.Count != 0)
        {
            
        }
        
    }

    public void FindObjectwithTag(string _tag, List<GameObject> list)
    {
        list.Clear();
        Transform parent = PlayerBody.transform;
        GetChildObject(parent, _tag, list);
    }

    public void GetChildObject(Transform parent, string _tag, List<GameObject> list)
    {
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                list.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                GetChildObject(child, _tag, list);
            }
        }
    }
}
