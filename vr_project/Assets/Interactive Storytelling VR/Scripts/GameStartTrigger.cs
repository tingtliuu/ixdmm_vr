using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameStartTrigger : MonoBehaviour
{

    void Start()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {

        StartCoroutine(dramaticStart());
        IEnumerator dramaticStart()
        {
            GameObject.FindGameObjectWithTag("CandleLight").GetComponent<Light>().intensity = 3;
            //Wait for 4 seconds
            yield return new WaitForSeconds(4);

            //GameObject.Find({ String Candelier_Single_Light}).getComponent<Light>().intensity = 3;

            GetComponent<GameManager>().gameStart = true;

        }

    }

}