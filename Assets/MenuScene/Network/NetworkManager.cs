using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    
    int layer = -1;

    public GameObject loadingObject;
    public GameObject roomObject;
    public GameObject UIObject;
    public GameObject waitingConnection;
    public TextMeshProUGUI inputRoomCode;
    public TextMeshProUGUI printRoomCode;

    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loadingObject.SetActive(false);
        UIObject.SetActive(true);
    }

    public void RoomButton()
    {
        layer = 1;
    }

    public void CreatOrJoinRoomButton()
    {

        //방 만들기
        PhotonNetwork.JoinOrCreateRoom(inputRoomCode.text, new RoomOptions{ MaxPlayers = 2 }, null );

        layer = 2;
        printRoomCode.text = inputRoomCode.text;

    }

    public override void OnJoinedRoom()
    {
        
    }

    void Update()
    {

        switch(layer)
        {

            case 0:

                UIObject.SetActive(true);
                roomObject.SetActive(false);

                break;

            case 1:

                UIObject.SetActive(false);
                roomObject.SetActive(true);
                waitingConnection.SetActive(false);

                break;

            case 2:

                roomObject.SetActive(false);
                waitingConnection.SetActive(true);

                break;

        }

        //뒤로가기
        if( Input.GetKeyDown( KeyCode.Escape ) && layer == 2 )
        {
            layer = 1;
            PhotonNetwork.LeaveRoom();
        }
        else if( Input.GetKeyDown( KeyCode.Escape ) && layer >= 0 )
        {
            layer -= 1;
        }
        
        if( PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom.PlayerCount == 2 )
        {
            SceneManager.LoadScene( "GameScene" );
        }

    }
}
