﻿using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerContrl : MonoBehaviour
{
    public GameObject player;

    public void WearGlasses1(int index)
    {
        player.GetComponent<PlayerPropty>().Glasses(index);
    }
}