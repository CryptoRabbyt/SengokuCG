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
                if (UserManager.Instance.userValidate(Request))
                {
                    UserManager.Instance.regUser(Request);
                    ClientEntity ce = new ClientEntity(Request);
                    UserEntity ue = UserManager.Instance.getContainUser(Request);
                    ue.SetClientEntity(ce);

                    Response.Redirect("./pages/Main.aspx?userName=" + ue.UserName);//HttpContext.Current.Server.MapPath("./pages/Main.aspx")+ "?userName="+ue.UserName
                }
                else
                {
                    //返回登录页面
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(HttpContext.Current.Server.MapPath("./pages/html/Login.html"));
                    body.InnerHtml = "<span> 验证用户失败 </span>" + xmlDoc.GetElementsByTagName("body")[0].InnerXml;
                }
            }
        }
    }
}