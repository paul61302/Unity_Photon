using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    static PhotonManager instance;

    public static PhotonManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PhotonManager>();
                if (instance == null)
                {
                    GameObject tmp = new GameObject("TutoriaPhotonManager");
                    instance = tmp.AddComponent<PhotonManager>();
                                       
                }
            }

            return instance;
        }

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 連線到Photon
    /// </summary>
    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
    }



    /// <summary>
    /// 創建房間
    /// </summary>
    /// <param name="RoomName"></param>
    public void CreateRoom(string RoomName)
    {
        // 設定房間條件{人數,可看見,可加入}
        RoomOptions options = new RoomOptions { MaxPlayers = 2, IsVisible = true, IsOpen = true };
        PhotonNetwork.CreateRoom(RoomName, options);
    }

    /// <summary>
    /// 加入房間
    /// </summary>
    /// <param name="RoomName"></param>
    public void JoinRoom(string RoomName)
    {
        if(string.IsNullOrEmpty(RoomName))
        {
            RoomName = " ";
        }

        PhotonNetwork.JoinRoom(RoomName);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);

        
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Game");
        PhotonNetwork.AutomaticallySyncScene = true;       
    }
}
