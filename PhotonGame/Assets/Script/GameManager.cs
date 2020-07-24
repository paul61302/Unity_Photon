using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*public AudioSource aud;
    public AudioClip auc;

    public Image begin;
    public bool beginBool;*/

    public ScenceManager scenceManager;

    private bool turn = true;

    public GameObject turn1;
    public GameObject turn2;

    /*private void Start()
    {
        aud = GameObject.FindObjectOfType<AudioSource>();
        beginBool = false;
    }

    void Update()
    {
        if(beginBool == false)
        {
            if (PhotonNetwork.CountOfPlayersInRooms == 2)
                    {
                        EventBegin();
                    }
        }
        
    }

    private void EventBegin()
    {
        beginBool = true;
        aud.PlayOneShot(auc, 1f);
        begin.enabled = true;

    }*/


    private void Update()
    {
        if(scenceManager.timer==0)
        {
            scenceManager.ButAgain.SetActive(true);
            turn = !turn;
        }
        if(turn == true)
        {
            turn1.SetActive(true);
            turn2.SetActive(false);
        }
        else 
        {
            turn2.SetActive(true);
            turn1.SetActive(false);
        }
    }

    public void Restart()
    {   
        scenceManager.timer = 5;
        scenceManager.timeCount.text = "5";
        scenceManager.ButAgain.SetActive(false);
    }

   
}
