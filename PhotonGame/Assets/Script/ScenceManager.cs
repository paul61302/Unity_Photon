using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ScenceManager : MonoBehaviour
{
    public GameObject PlayerCtr;
    public PlayerContrl Player;

    void Start()
    {
        if (PhotonNetwork.CountOfPlayersInRooms != 0)
        {
            GameObject Player2 =  PhotonNetwork.Instantiate("Player2", new Vector3(1430,550,0), Quaternion.identity);
            Player2.transform.parent = PlayerCtr.transform;
            Player.player = Player2;
        }
           
       else
        {
            GameObject Player1 = PhotonNetwork.Instantiate("Player1", new Vector3(550, 550, 0), Quaternion.identity);
            Player1.transform.parent = PlayerCtr.transform;
            Player1.transform.rotation = new Quaternion(0, -180, 0, 0);
            Player.player = Player1;
        }
            
               
    }

    
}
