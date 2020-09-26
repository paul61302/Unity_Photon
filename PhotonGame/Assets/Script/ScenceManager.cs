using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using ExitGames.Client.Photon;

public class ScenceManager : MonoBehaviourPunCallbacks, IOnEventCallback, IPunObservable
{
    public GameObject PlayerCtr;
    public PlayerContrl Player;
    public int timer = 5;
    public Text timeCount;
    public GameObject ButAgain;

    
    void Start()
    {
        #region 生成玩家
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
        #endregion           
    }

    #region 計時

    // 當有新玩家加入時執行
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.PlayerList.Length == 2 && PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
      
        WaitForSecondsRealtime ww = new WaitForSecondsRealtime(1f);
        while (timer > 0)
        {
            yield return ww;
            timer--;
            timeCount.text = timer.ToString();
            byte evntcode = 1;
            object[] obj = new object[] { timer };
            RaiseEventOptions EventOption = new RaiseEventOptions { Receivers = ReceiverGroup.All };
            PhotonNetwork.RaiseEvent(evntcode, obj, EventOption, SendOptions.SendReliable);
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        /*
        switch (photonEvent.Code)
        {
            case 1:
                {
                    object[] data = (object[])photonEvent.CustomData;
                    timeCount.text = data[0].ToString();
                    break;
                }
            case 2:
                {
                    object[] data = (object[])photonEvent.CustomData;
                    timeCount.text = data[0].ToString();
                    break;
                }
        }
        */

        if (photonEvent.Code == 1)
        {
            // 先轉出型態 將複數陣列轉成單一
            object[] date = (object[])photonEvent.CustomData;
            // 將date[0] 顯示在TIMER上
            timeCount.text = date[0].ToString();

        }
       
    }

   public override void OnEnable()

    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    #endregion

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
    }
}
