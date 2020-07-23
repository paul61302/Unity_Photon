using UnityEngine;
using Photon.Pun;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip auc;

    public Image begin;
    public bool beginBool;

    private void Start()
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

    }
}
