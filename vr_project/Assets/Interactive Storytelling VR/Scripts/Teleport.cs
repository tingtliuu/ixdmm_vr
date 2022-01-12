using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem.Sample;

public class Teleport : MonoBehaviour
{
    private bool startFade = false;
    private GameObject Player;
    [SerializeField] int fadeTimer = 2;
    [SerializeField] GameObject TeleportTrigger;
    [SerializeField] GameObject NewPlayerBody;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject LeftHand;
    [SerializeField] GameObject RightHand;
    [SerializeField] GameObject PlayerDoll;
    [SerializeField] Transform PlayerTargetLocation;    
    [SerializeField] Transform DollTargetLocation;
    
    private List<GameObject> Head = new List<GameObject>();
    private List<GameObject> Arms = new List<GameObject>();

    public bool activateTeleport;

    private void Start()
    {
        this.TeleportTrigger.GetComponent<TeleportTrigger>().Teleport = this;
        Player = GetComponent<GameManager>().Player;
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
                FadeOut();
                StartCoroutine(TeleportPlayer(fadeTimer));
                //cloneDoll();
                //StartCoroutine(ConnectToPlayerBody(fadeTimer));
            }
            else
            {
                FadeIn();
                activateTeleport = false;
            }
           
        }
    }

    IEnumerator ConnectToPlayerBody(float s)
    {
        yield return new WaitForSecondsRealtime(s);
        Head[0].transform.parent = Camera.transform;
        Arms[0].transform.parent = LeftHand.transform;
        Arms[1].transform.parent = RightHand.transform;

        Camera.transform.position = Head[0].transform.position;
        LeftHand.transform.position = Arms[0].transform.position;
        RightHand.transform.position = Arms[1].transform.position;
    }

    void FadeOut()
    {
        SteamVR_Fade.Start(Color.clear, 0);
        SteamVR_Fade.Start(Color.black, fadeTimer);
    }

    void FadeIn()
    {
        SteamVR_Fade.Start(Color.black, 0);
        SteamVR_Fade.Start(Color.clear, fadeTimer);
    }

    IEnumerator TeleportPlayer(float s)
    {
        yield return new WaitForSecondsRealtime(s);
        Player.transform.position = PlayerTargetLocation.position;
        Player.transform.eulerAngles = PlayerTargetLocation.eulerAngles;
        cloneDoll();
        PlayerDoll.transform.position = DollTargetLocation.position;
        PlayerDoll.transform.eulerAngles = (DollTargetLocation.eulerAngles + new Vector3(0,90,0));
        PlayerDoll.transform.parent = DollTargetLocation;
        PlayerDoll.GetComponentInChildren<DollMover>().enabled = true;
        activateTeleport = true;
    }

    public void FindObjectwithTag(string _tag, List<GameObject> list, GameObject target)
    {
        list.Clear();
        Transform parent = target.transform;
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

    void cloneDoll()
    {
        GameObject tempPlayerDoll = PlayerDoll;
        tempPlayerDoll.transform.localScale *= 2;
        Component[] LockedLimbs = tempPlayerDoll.GetComponentsInChildren<LockToPoint>();
        
        foreach (Component Limb in LockedLimbs)
        {
            Limb.GetComponent<LockToPoint>().enabled = false;
        }

        GameObject clone =  Instantiate(tempPlayerDoll, PlayerTargetLocation);
        clone.transform.position = NewPlayerBody.transform.position;
        clone.transform.eulerAngles = NewPlayerBody.transform.eulerAngles;

        Transform[] allChildren = clone.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            child.gameObject.layer = 6;
            //child.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        Collider[] children = clone.GetComponentsInChildren<BoxCollider>();
        foreach (Collider child in children)
        {
            child.GetComponent<BoxCollider>().enabled = false;
        }
        
        clone.layer = 6;
        FindObjectwithTag("DollArm", Arms, clone);
        FindObjectwithTag("DollHead", Head, clone);
    }
}
