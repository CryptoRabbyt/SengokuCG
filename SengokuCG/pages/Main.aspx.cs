using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace SengokuCG.pages
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.IsWebSocketRequest)
            {
                Context.AcceptWebSocketRequest(UserThread);
            }
        }

        private async Task UserThread(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;

            await socket.SendAsync(new ArraySegment<byte>(Encoding.Default.GetBytes("hello"+context.QueryString["userName"])), WebSocketMessageType.Text, true, CancellationToken.None);
            
        }
    }
}