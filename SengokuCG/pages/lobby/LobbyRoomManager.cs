using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages.lobby
{
    public class LobbyRoomManager
    {
        #region 单例
        private static LobbyRoomManager instance;
        private LobbyRoomManager() { }

        public static LobbyRoomManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LobbyRoomManager();
                }
                return instance;
            }
        }
        #endregion

        public event Action<List<LobbyRoomEntity>> update;

        private List<LobbyRoomEntity> roomList = new List<LobbyRoomEntity>();

        public void AddRoom(LobbyRoomEntity roomEntity)
        {
            roomList.Add(roomEntity);
            update(roomList);
        }
    }
}