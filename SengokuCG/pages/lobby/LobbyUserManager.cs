using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages.lobby
{
    public class LobbyUserManager
    {
        #region 单例
        private static LobbyUserManager instance;
        private LobbyUserManager() { }

        public static LobbyUserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LobbyUserManager();
                }
                return instance;
            }
        }
        #endregion
        

        //private Dictionary<string, UserEntity> userEntityDic = new Dictionary<string, UserEntity>();
        //public Dictionary<string, UserEntity> UserEntityDic
        //{
        //    get
        //    {
        //        return userEntityDic;
        //    }

        //    set
        //    {
        //        userEntityDic = value;
        //    }
        //}
        ///// <summary>
        ///// 查询请求用户是否已登录
        ///// </summary>
        ///// <param name="userName"></param>
        ///// <returns></returns>
        //public bool IsContainUser(string userName)
        //{
        //    foreach (var userEntityKV in UserEntityDic)
        //    {
        //        if (userEntityKV.Value.UserName == userName)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 添加用户实体
        ///// </summary>
        ///// <param name="ue"></param>
        ///// <returns></returns>
        //public bool AddUser(UserEntity ue)
        //{
        //    if (!IsContainUser(ue.UserName))
        //    {
        //        UserEntityDic.Add(ue.UserName, ue);
        //        return true;
        //    }
        //    return false;
        //}
        ///// <summary>
        ///// 移除用户实体
        ///// </summary>
        ///// <param name="ue"></param>
        ///// <returns></returns>
        //public bool RemoveUser(UserEntity ue)
        //{
        //    if (IsContainUser(ue.UserName))
        //    {
        //        UserEntityDic.Remove(ue.UserName);
        //        return true;
        //    }
        //    return false;
        //}
    }
}