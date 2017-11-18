using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages.lobby
{
    public class LobbyManager
    {
        #region 单例
        private static LobbyManager instance;
        private LobbyManager() { }

        public static LobbyManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LobbyManager();
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