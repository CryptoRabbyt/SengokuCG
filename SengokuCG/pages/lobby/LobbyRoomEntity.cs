using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages.lobby
{
    public class LobbyRoomEntity
    {
        private UserEntity player01;
        private UserEntity player02;

        public UserEntity Player01
        {
            get
            {
                return player01;
            }

            set
            {
                player01 = value;
            }
        }

        public UserEntity Player02
        {
            get
            {
                return player02;
            }

            set
            {
                player02 = value;
            }
        }
    }
}