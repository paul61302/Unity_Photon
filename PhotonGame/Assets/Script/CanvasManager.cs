using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CanvasManager : MonoBehaviourPunCallbacks
{
    public Button CreateRoom;
    public Button JoinRoom;
    public Button JoinRanRoom;
    public InputField RoomName;
    public Text State;

    private void Start()
    {
        PhotonManager.Instance.ConnectToMaster();
        
        //創建房間
        CreateRoom.onClick.AddListener(() =>
        {
            PhotonManager.Instance.CreateRoom(RoomName.text);
            State.text = "創建房間中";
        });
        //加入房間
        JoinRoom.onClick.AddListener(() => 
        {
            PhotonManager.Instance.JoinRoom(RoomName.text);
            State.text = "已加入";
        });

        JoinRanRoom.onClick.AddListener(() => 
        {
            PhotonManager.Instance.JoinRandomRoom();
            State.text = "正在配對中";
        });

    }


   

    public override void OnConnectedToMaster()
    {
        State.text = "已連線";
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);

        State.text = "房間不存在";

    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);

        State.text = "沒有房間可以加入";
        RoomName.text = "";
    }
}
