using UnityEngine;
using Photon.Pun;

public class PlayerPropty : MonoBehaviour
{
    PhotonView pv;
    PlayerContrl myController;


   void Start()
    {
        pv = GetComponent<PhotonView>();
        if(pv.IsMine)
        {
            
        }
    }

    void Update()
    {
        myController = FindObjectOfType<PlayerContrl>();

    }
}
