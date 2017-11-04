using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace SengokuCG.pages
{
    public class UserManager
    {
        #region 单例
        private static UserManager instance;
        private UserManager() { }

        public static UserManager Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new UserManager();
                }
                return instance;
            }
        }
        #endregion

        private List<UserEntity> userEntityList = new List<UserEntity>();
        public List<UserEntity> UserEntityList
        {
            get
            {
                return userEntityList;
            }

            set
            {
                userEntityList = value;
            }
        }

        /// <summary>
        /// 查询请求用户是否已登录
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool IsContainUser(HttpRequest hr)
        {
            foreach (var userEntity in UserEntityList)
            {
                if (userEntity.Equal(hr))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 查询请求用户是否已登录
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool IsContainUser(UserEntity ue)
        {
            foreach (var userEntity in UserEntityList)
            {
                if (userEntity.Equal(ue))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取已登录的用户
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public UserEntity GetContainUser(HttpRequest hr)
        {
            foreach (var userEntity in UserEntityList)
            {
                if (userEntity.Equal(hr))
                {
                    return userEntity;
                }
            }
            return null;
        }

        /// <summary>
        /// 注册用户实体
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool RegUser(HttpRequest hr)
        {
            if (!IsContainUser(hr))
            {
                UserEntity ue = new UserEntity(hr);
                UserEntityList.Add(ue);

                RemoveUserEntityAfterWait(ue, 60000);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool UserValidate(HttpRequest hr)
        {
            return true;
        }
        /// <summary>
        /// 一定时间之后把指定用户移出用户列表，表示该用户已不在线上
        /// </summary>
        /// <param name="ue">指定用户</param>
        /// <param name="time">指定时间之后</param>
        private void RemoveUserEntityAfterWait(UserEntity ue,int time)
        {
            Thread th = new Thread(new ThreadStart(() => {
                Thread.Sleep(time);
                if (ue.ConnectedSocket==null)
                {
                    this.UserEntityList.Remove(ue);
                }
            }));
            th.IsBackground = true;
            th.Start();
        }
    }
}