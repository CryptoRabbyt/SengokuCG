using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SengokuCG.pages
{
    public class ClientManager
    {
        #region 单例
        private static ClientManager instance;
        private ClientManager() { }

        public static ClientManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientManager();
                }
                return instance;
            }
            
        }
        #endregion

        private List<ClientEntity> clientEntityList = new List<ClientEntity>();
        public List<ClientEntity> ClientEntityList
        {
            get
            {
                return clientEntityList;
            }

            set
            {
                clientEntityList = value;
            }
        }

        /// <summary>
        /// 查询请求客户端是否已被记录
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool isContainClient(HttpRequest hr)
        {
            foreach (var clientEntity in ClientEntityList)
            {
                if (clientEntity.Equal(hr))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 查询请求客户端是否已被记录
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public bool isContainClient(ClientEntity ce)
        {
            foreach (var clientEntity in ClientEntityList)
            {
                if (clientEntity.Equal(ce))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取已被记录的客户端
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public ClientEntity getContainClient(HttpRequest hr)
        {
            foreach (var clientEntity in ClientEntityList)
            {
                if (clientEntity.Equal(hr))
                {
                    return clientEntity;
                }
            }
            return null;
        }

        ///// <summary>
        ///// 使用请求信息查询该客户端是否已经登录了用户
        ///// </summary>
        ///// <param name="hr"></param>
        ///// <returns>已登录则返回ClientEntity，否则返回null</returns>
        //public UserEntity getClientUser(HttpRequest hr)
        //{
        //    foreach (var clientEntity in ClientEntityList)
        //    {
        //        if (clientEntity.Equal(hr))
        //        {
        //            return clientEntity.getUserEntity();
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// 注册客户端实体
        /// </summary>
        /// <param name="hr"></param>
        /// <returns></returns>
        public bool regClient(HttpRequest hr)
        {
            if (!isContainClient(hr))
            {
                ClientEntityList.Add(new ClientEntity(hr));
                return true;
            }
            return false;
        }
    }
}