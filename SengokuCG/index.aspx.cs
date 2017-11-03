using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SengokuCG.pages;

namespace SengokuCG
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hidden"] == null)//第一次请求
            {
                UserEntity ue;
                if ((ue =ClientManager.Instance.getClientUser(Request))!=null)
                {
                    //-----------------test---------------------
                    Response.Write("欢迎你" + ue.UserName);
                    //-----------------test---------------------
                    switch (ue.CurGameState)
                    {
                        case GameState.Lobby:
                            break;
                        case GameState.Room:
                            break;
                        case GameState.Game:
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                ClientManager.Instance.regClient(Request);
                UserManager.Instance.regUser(Request);
                ClientManager.Instance.getContainClient(Request).addUserEntity(UserManager.Instance.getContainUser(Request));

                //-----------------test---------------------
                foreach (var item in UserManager.Instance.UserEntityList)
                {
                    Response.Write(item.UserName);
                }
                //-----------------test---------------------
            }
        }
    }
}