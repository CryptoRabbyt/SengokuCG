using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SengokuCG.pages
{
    public class ReconnectUserManager
    {
        #region 单例
        private static ReconnectUserManager instance;
        private ReconnectUserManager() { }

        public static ReconnectUserManager Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new ReconnectUserManager();
                }
                return instance;
            }
        }
        #endregion

        private Dictionary<string,UserEntity> userEntityDic = new Dictionary<string, UserEntity>();
        public Dictionary<string, UserEntity> UserEntityDic
        {
            get
            {
                return userEntityDic;
            }

            set
            {
                userEntityDic = value;
            }
        }
        
        /// <summary>
        /// 查询请求用户是否已登录
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool IsContainUser(UserEntity ue)
        {
            if (UserEntityDic.ContainsKey(ue.UserName))
            {
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// 获取已登录的用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        public UserEntity GetContainUser(string userName)
        {
            if (userEntityDic.ContainsKey(userName))
            {
                return userEntityDic[userName];
            }
            return null;
        }

        /// <summary>
        /// 注册用户实体
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool RegUser(string userName,UserEntity ue)
        {
            if (!userEntityDic.ContainsKey(userName))
            {
                UserEntityDic.Add(userName,ue);
                RemoveUserEntity(ue, 60000);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 一定时间之后把指定用户移出用户列表，表示该用户已不在线上
        /// </summary>
        /// <param name="ue">指定用户</param>
        /// <param name="delayTime">指定时间之后</param>
        public void RemoveUserEntity(UserEntity ue,int delayTime)
        {
            Thread th = new Thread(new ThreadStart(() => {
                Thread.Sleep(delayTime);
                this.UserEntityDic.Remove(ue.UserName);
            }));
            th.IsBackground = true;
            th.Start();
        }
        /// <summary>
        /// 指定用户移出用户列表，表示该用户已不在线上
        /// </summary>
        /// <param name="ue">指定用户</param>
        public void RemoveUserEntity(UserEntity ue)
        {
            this.UserEntityDic.Remove(ue.UserName);
        }
    }
}