using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnowBrothers.SnowFighters.OSproject
{
    public class Launcher : Photon.PunBehaviour
    {
        [Tooltip("The UI Panel to let the user enter name, connect and play")]
        public GameObject controlPanel;
        [Tooltip("The UI Label to inform the user that the connention is in progress")]
        public GameObject progressLabel;

        //PUN loglevel
        public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

        #region PUblic Variables

        [Tooltip("The maximun number of players per room. When a room is full, it can't be joined by new players, and so new will be created")]
        public byte MaxPlayersPerRoom = 4;

        #endregion

        #region Private Variables

        //version number
        string _gameVersion = "1";

        bool isConnectiong;

        #endregion

        #region MonoBehaviour CallBacks

        //MonoBehaviour method called on GameObject by Unity during early initialization lhase

        void Awake()
        {
            // #별로 안중요
            // 네트워크 로그레벨 최대
            PhotonNetwork.logLevel = Loglevel;

            // #Critical
            // 로비에 안들어감. 로비리스트를 가져오기 위해 로비에 들어갈 필요 없음
            PhotonNetwork.autoJoinLobby = false;

            // #Critical
            // PhotonNetwork.LoadLevel()를 마스터 클라이언트와 같은 방의 모든 클라이언트에서 사용해서 레벨을 자동으로 싱크할 수 있게 해줌.
            PhotonNetwork.automaticallySyncScene = true;
        }

        // MonoBehaviour method는 실행단계일 때 유니티에 의해 GameObject를 호출한다.
        void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }

        #endregion

        #region Public Methods

        // 연결 프로세스 시작
        // -만약 이미 연결되어있으면, 랜덤 방에 참가 시도
        // -아직 연겨링 안되있으면,  이 응용의 경우를 포톤클라우드 네트워크에 연결한다.

        public void Connect()
        {
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);
            isConnectiong = true;

            //연결 여부 확인, 연결되었다면, 아니면 서버에 연결
            if (PhotonNetwork.connected)
            {
                // #Critical 랜덤방에 참가를 시도하기 위해 이 부분이 필요. 실패하면 onPhotonRandomJoinFailed()를 확인받고, 방을 만든다.
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical 포톤 온라인 서버에 대해 가장 처음이고 맨 앞이어야 한다.
                // 게임이 네트워크를 통하여 포톤클라우드로 연결되는 시작점
                PhotonNetwork.ConnectUsingSettings(_gameVersion);

            }
        }
        #endregion

        #region Photon.PunBehaviour CallBacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
            if (isConnectiong)
            {
                PhotonNetwork.JoinRandomRoom();
            }
        
        }

        public override void OnDisconnectedFromPhoton()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);

            Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            Debug.Log("DemoAnimator/Launcher: OnPhotonRandomJoinFailed() was called by PUN. NO random room");
            PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("DemoAnimator/launcher: OnJoinedRoom() called by PUN. Now this client is in a random room.");

            //#중요 : 우리가 첫 플레이어일 때만 불러온다. 그게 아니라면 우리는 PhotonNetwork.automaticallySyncScene가 우리의 인스턴스 신을 싱크하도록 한다.
            if(PhotonNetwork.room.playerCount == 1)
            {
                Debug.Log("We load the 'Room for 1'");

                //#중요
                //Load the Room Level
                PhotonNetwork.LoadLevel("Room for 1");
            }

        }

        #endregion
    }
}

