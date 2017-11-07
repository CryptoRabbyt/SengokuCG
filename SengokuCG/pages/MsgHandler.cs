using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SengokuCG.pages
{
    public class MsgHandler
    {
        #region 单例
        private static MsgHandler instance;
        private MsgHandler() { }

        public static MsgHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsgHandler();
                }
                return instance;
            }
        }
        #endregion

        public void ParseMsg(string msg)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(msg);

            switch (xmlDoc.DocumentElement.Attributes["Id"].Value)
            {
                case "1001":
                    OpenRoom(xmlDoc);
                    break;
            }
        }

        private void OpenRoom(XmlDocument xmlDoc)
        {
            throw new NotImplementedException();
        }
    }
}