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

        public ClientEntity(string userHostAddress,string userAgent)
        {
            clientHostAddress = userHostAddress;
            clientAgent = userAgent;
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
        /// <summary>
        /// 判断该客户端与请求客户端是否相同
        /// </summary>
        /// <param name="ce"></param>
        /// <returns></returns>
        public bool Equal(string userHostAddress, string userAgent)
        {
            return clientHostAddress == userHostAddress && clientAgent == userAgent;
        }
    }
}