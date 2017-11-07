using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SengokuCG.pages
{
    public class MsgSender
    {
        #region 单例
        private static MsgSender instance;
        private MsgSender() { }

        public static MsgSender Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsgSender();
                }
                return instance;
            }
        }
        #endregion

        public Task SendMsg(WebSocket ws, string msg)
        {
            return ws.SendAsync(new ArraySegment<byte>(Encoding.Default.GetBytes(msg)), WebSocketMessageType.Text, true, CancellationToken.None);
        }

    }
}