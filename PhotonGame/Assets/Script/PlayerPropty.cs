using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerPropty : MonoBehaviour
{
    public PhotonView pv;
    //public PlayerContrl PlayerCtr;
    public Sprite[] glasses;
    public Image myglasses;

    public void Glasses(int glasses)
    {
        pv.RPC("ChangeGlasses", RpcTarget.All, glasses);
    }

    [PunRPC]
    public void ChangeGlasses(int index)
    {
        myglasses.sprite = glasses[index];
    }
    
        
}
