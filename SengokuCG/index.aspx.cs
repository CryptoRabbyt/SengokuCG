using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SengokuCG.pages;
using System.Xml;

namespace SengokuCG
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hidden"] == null)//第一次请求
            {
                //返回登录页面
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(HttpContext.Current.Server.MapPath("./pages/html/Login.html"));
                body.InnerHtml = xmlDoc.GetElementsByTagName("body")[0].InnerXml;
            }
            else//用户登录处理
            {
                UserValidateCode userUC = UserManager.Instance.UserValidate(Request.Form);
                ClientEntity ce = new ClientEntity(Request.UserHostAddress, Request.UserAgent);
                if (userUC == UserValidateCode.Validation)//验证通过
                {
                    UserEntity ue = new UserEntity(Request.Form["userName"]);
                    ReconnectUserManager.Instance.RegUser(Request.Form["userName"], ue);
                    ue = ReconnectUserManager.Instance.GetContainUser(Request.Form["userName"]);
                    ue.SetClientEntity(ce);

                    Response.Redirect("./pages/Main.aspx?userName=" + ue.UserName);//HttpContext.Current.Server.MapPath("./pages/Main.aspx")+ "?userName="+ue.UserName
                }
                else if (userUC == UserValidateCode.Online&& ReconnectUserManager.Instance.GetContainUser(Request.Form["userName"]).ConnectedClient==ce)//断线重连
                {
                    UserEntity ue=ReconnectUserManager.Instance.GetContainUser(Request.Form["userName"]);
                    Response.Redirect("./pages/Main.aspx?userName=" + ue.UserName);
                }
                else if (userUC == UserValidateCode.Online)
                {
                    //返回登录页面
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(HttpContext.Current.Server.MapPath("./pages/html/Login.html"));
                    body.InnerHtml = "<span> 该用户已处于登录状态 </span>" + xmlDoc.GetElementsByTagName("body")[0].InnerXml;
                }
            }
        }
    }
}