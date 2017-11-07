using SengokuCG.pages.lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Web;

namespace SengokuCG.pages
{
    public enum GameState
    {
        None,
        Lobby,
        Room,
        Game,
    }

    public class UserEntity
    {
        private string userName;
        private GameState curGameState=GameState.None;//设定初始状态为NONE
        private ClientEntity connectedClient;
        private WebSocket connectedSocket;
        

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public WebSocket ConnectedSocket
        {
            get
            {
                return connectedSocket;
            }

            set
            {
                connectedSocket = value;
            }
        }

        public ClientEntity ConnectedClient
        {
            get
            {
                return connectedClient;
            }

            set
            {
                connectedClient = value;
            }
        }

        public UserEntity(string userName)
        {
            UserName = userName;
        }
        
        /// <summary>
        /// 该用户与请求用户是否相同
        /// </summary>
        /// <param name="ue"></param>
        /// <returns></returns>
        public bool Equal(UserEntity ue)
        {
            return UserName == ue.UserName;
        }
        /// <summary>
        /// 添加用户关联的客户端实体，无论是否重复
        /// </summary>
        /// <param name="ce"></param>
        /// <returns>添加成功返回TRUE，否则返回FALSE</returns>
        public bool SetClientEntity(ClientEntity ce)
        {
            ConnectedClient=ce;
            return true;
        }
        /// <summary>
        /// 当用户连接时的初始化操作，把用户引入属于各自状态的空间
        /// </summary>
        public void InitUserConnect()
        {
            if (curGameState == GameState.None)
            {
                curGameState = GameState.Lobby;
            }
            InitUserSpace();
        }
        /// <summary>
        /// 根据用户的现有状态初始化用户空间
        /// </summary>
        public void InitUserSpace()
        {
            switch (curGameState)
            {
                case GameState.None:
                    break;
                case GameState.Lobby:
                    LobbyRoomManager.Instance.update += UserEntity_OnRoomUpdate;
                    break;
                case GameState.Room:
                    break;
                case GameState.Game:
                    break;
                default:
                    break;
            }
        }

        private void UserEntity_OnRoomUpdate(List<LobbyRoomEntity> roomList)
        {
            string msg = MsgCoder.Instance.CodeRoomUpdate(roomList);
            MsgSender.Instance.SendMsg(connectedSocket, msg);
            
        }

        /// <summary>
        /// 退出用户所在空间
        /// </summary>
        public void ExitUserSpace()
        {
            switch (curGameState)
            {
                case GameState.None:
                    break;
                case GameState.Lobby:
                    //LobbyUserManager.Instance.RemoveUser(this);
                    break;
                case GameState.Room:
                    break;
                case GameState.Game:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 重新设定用户的状态，切换其所在的空间
        /// </summary>
        /// <param name="gs"></param>
        public void SetGameState(GameState gs)
        {
            ExitUserSpace();
            curGameState = gs;
            InitUserSpace();
        }


    }
}