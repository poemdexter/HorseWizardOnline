using UnityEngine;

public class NetworkJoin : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    private void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    private void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    private void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate("HorsePlayer", Vector3.zero, Quaternion.identity, 0);
        EnableControlledPlayerComponents(player);
    }

    private static void EnableControlledPlayerComponents(GameObject player)
    {
        player.transform.FindChild("Main Camera").GetComponent<Camera>().enabled = true;
        player.transform.FindChild("Main Camera").GetComponent<AudioListener>().enabled = true;
        player.transform.GetComponent<PlayerAttack>().enabled = true;
    }
}