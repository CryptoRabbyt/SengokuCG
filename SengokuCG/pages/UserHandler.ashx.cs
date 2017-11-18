using SengokuCG.pages.lobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace SengokuCG.pages
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(UserThread);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private async Task UserThread(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            //获取Socket所要绑定的用户实体
            UserEntity ue = ReconnectUserManager.Instance.GetContainUser(context.QueryString["userName"]);
            ue.ConnectedSocket = socket;


            //把用户从重连实体池转移到在线实体池
            ReconnectUserManager.Instance.RemoveUserEntity(ue);
            UserManager.Instance.RegUser(ue);

            ue.InitUserConnect();//当用户连接时的初始化操作，把用户引入属于各自状态的空间
            
            //循环等待并获取客户端信息
            while (true)
            {
                if (socket.State == WebSocketState.Open)
                {
                    ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
                    WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);

                    string userMsg = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);//发送过来的消息

                    //--------------------测试------------------------
                    LobbyManager.Instance.AddRoom(new LobbyRoomEntity());
                }
            }
        }

    }
}