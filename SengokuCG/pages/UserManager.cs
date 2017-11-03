using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool isContainUser(HttpRequest hr)
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
        public bool isContainUser(UserEntity ue)
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
        public UserEntity getContainUser(HttpRequest hr)
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
        public bool regUser(HttpRequest hr)
        {
            if (!isContainUser(hr))
            {
                UserEntityList.Add(new UserEntity(hr));
                return true;
            }
            return false;
        }
    }
}