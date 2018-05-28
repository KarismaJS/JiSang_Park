using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnowBrothers.SnowFighters.OSproject
{
    public class GameManager : Photon.PunBehaviour
    {
        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.playerCount);
            PhotonNetwork.LoadLevel("Room for" + PhotonNetwork.room.playerCount);
        }

        #endregion

        #region Photon Messages

        //로컬플레이어가 룸을 떠날때 런처신을 불러온다.
        public void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Photon Messages

        //PhotonNetwork.isMasterClient를 이용해서 마스터인 경우에만 LoadArena() 호출
        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerConnected()" + other.name); //내가 연결중인 플레이어가 아닐때.

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerConnected isMasterClient" + PhotonNetwork.isMasterClient);//OnPhotonPlayerDisconnected 전에 불러온다.
                LoadArena();
            }
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected()" + other.name);// 다른 연결해제를 봤을 때.

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlaterConnected isMasterClient" + PhotonNetwork.isMasterClient); //OnPhotonPlayerDisconnected 전에 불러온다.

                LoadArena();
            }
        }

        #endregion
    }

}
