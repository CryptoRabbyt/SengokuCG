﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public UserEntity(HttpRequest hr)
        {
            UserName = hr["userName"];
        }
        /// <summary>
        /// 该用户与请求用户是否相同
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool Equal(HttpRequest hr)
        {
            return UserName == hr["userName"];
        }
        /// <summary>
        /// 该用户与请求用户是否相同
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool Equal(UserEntity ue)
        {
            return UserName == ue.UserName;
        }
    }
}