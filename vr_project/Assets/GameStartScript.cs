using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.GetComponent<GameManager>().gameStart = true;
            GetComponent<GameStartScript>().enabled = false;
        }
    }
}
