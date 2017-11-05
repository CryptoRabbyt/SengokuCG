using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SengokuCG.pages
{
    public enum UserValidateCode
    {
        Validation,
        Online,
    }
    public class UserManager
    {
        #region 单例
        private static UserManager instance;
        private UserManager() { }

        public static UserManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserManager();
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
        /// 用户登录验证
        /// </summary>
        /// <param name="loginForm">用户的登录表单</param>
        /// <returns></returns>
        public UserValidateCode UserValidate(NameValueCollection loginForm)
        {
            if (IsContainUser(loginForm["userName"]))
            {
                return UserValidateCode.Online;
            }
            return UserValidateCode.Validation;
        }
        /// <summary>
        /// 查询请求用户是否已登录
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool IsContainUser(UserEntity ue)
        {
            foreach (var userEntityKV in UserEntityDic)
            {
                if (userEntityKV.Value.Equal(ue))
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
        public bool IsContainUser(string userName)
        {
            foreach (var userEntityKV in UserEntityDic)
            {
                if (userEntityKV.Value.UserName==userName)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 注册用户实体
        /// </summary>
        /// <param name="ue"></param>
        /// <returns></returns>
        public bool RegUser(UserEntity ue)
        {
            if (!IsContainUser(ue))
            {
                UserEntityDic.Add(ue.UserName,ue);
                return true;
            }
            return false;
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