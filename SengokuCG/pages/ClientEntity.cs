using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages
{
    public class ClientEntity
    {
        private string clientHostAddress;
        private string clientAgent;
        private List<UserEntity> connectedUserList=new List<UserEntity>();

        public List<UserEntity> ConnectedUserList
        {
            get
            {
                return connectedUserList;
            }

            set
            {
                connectedUserList = value;
            }
        }

        public ClientEntity(HttpRequest hr)
        {
            clientHostAddress = hr.UserHostAddress;
            clientAgent = hr.UserAgent;
        }
        /// <summary>
        /// 判断该客户端与请求客户端是否相同
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool Equal(HttpRequest hr)
        {
            return clientHostAddress == hr.UserHostAddress && clientAgent == hr.UserAgent;
        }
        /// <summary>
        /// 判断该客户端与请求客户端是否相同
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public bool Equal(ClientEntity ce)
        {
            return clientHostAddress == ce.clientHostAddress && clientAgent == ce.clientAgent;
        }

        ///// <summary>
        ///// 获得客户端最新登录的用户
        ///// </summary>
        ///// <returns></returns>
        //public UserEntity getUserEntity()
        //{
        //    if (connectedUserList.Count>0)
        //    {
        //        return connectedUserList[connectedUserList.Count - 1];
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// 添加客户端关联的用户实体，无论是否重复
        ///// </summary>
        ///// <param name="ue"></param>
        ///// <returns>添加成功返回TRUE，否则返回FALSE</returns>
        //public bool addUserEntity(UserEntity ue)
        //{
        //    connectedUserList.Add(ue);
        //    return true;
        //}
    }
}