using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Web;

namespace SengokuCG.pages
{
    enum GameState
    {
        Lobby,
        Room,
        Game,
    }

    public class UserEntity
    {
        private string userName;
        private GameState curGameState=GameState.Lobby;
        private ClientEntity connectedClient;
        private WebSocket connectedSocket;

        internal GameState CurGameState
        {
            get
            {
                return curGameState;
            }

            set
            {
                curGameState = value;
            }
        }

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
            connectedClient=ce;
            return true;
        }
    }
}