﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidenuttons : MonoBehaviour
{
    public GameObject start, lobby, gamemodechoose, styling, scores, text, allbuttons, paneldifficult, MusicManager;
    void Update()
    {
        Whattodoonline();

    }
    public void Online()
    {
        Whattodoonline();
        gamemodechoose.SetActive(false);
        lobby.SetActive(true);
        allbuttons.SetActive(false);
        PhotonNetwork.JoinLobby(TypedLobby.Default);

    }
    public void Offline()
    {
        paneldifficult.SetActive(true);
    }
    public void Back()
    {
        WhattodoBack();
        gamemodechoose.SetActive(false);
        
    }
    public void Onlineback()
    {
        allbuttons.SetActive(true);
        Back();
        lobby.SetActive(false);
    }
    private void WhattodoBack()
    {
        start.SetActive(true);
        styling.SetActive(true);
<<<<<<< HEAD
        scores.SetActive(true);
=======
        //scores.SetActive(true);
>>>>>>> 46f6557c006040dbc335ccb9f08f0d9b60ad214f
        MusicManager.SetActive(true);
        text.SetActive(true);
    }
    private void Whattodoonline()
    {
        start.SetActive(false);
        styling.SetActive(false);
        //scores.SetActive(false);
        text.SetActive(false);
        
    }
}
