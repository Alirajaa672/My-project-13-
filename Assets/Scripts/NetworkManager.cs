using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("Room1");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom("Room1");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.Instantiate("CarPrefab", new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0), Quaternion.identity);
    }

}
