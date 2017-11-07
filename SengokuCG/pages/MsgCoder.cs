using SengokuCG.pages.lobby;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace SengokuCG.pages
{
    public class MsgCoder
    {
        #region 单例
        private static MsgCoder instance;
        private MsgCoder() { }

        public static MsgCoder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MsgCoder();
                }
                return instance;
            }
        }
        #endregion

        public string CodeRoomUpdate(List<LobbyRoomEntity> roomList)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<Msg Id='20101'>fuckyou</Msg>");

            //for (int i = 0; i < roomList.Count; i++)
            //{
            //    XmlElement xmlEleRoom= xmlDoc.CreateElement("Room");
            //    xmlEleRoom.SetAttribute("Id",i.ToString());
            //    xmlDoc.AppendChild(xmlEleRoom);

            //    XmlElement xmlElePlayer01 = xmlDoc.CreateElement("Player01");
            //    xmlEleRoom.AppendChild(xmlElePlayer01);


            //    XmlElement xmlElePlayer02 = xmlDoc.CreateElement("Player02");
            //    xmlEleRoom.AppendChild(xmlElePlayer02);
            //}

            return ConvertXmlToString(xmlDoc);
        }

        public string ConvertXmlToString(XmlDocument xmlDoc)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(stream, null);
            writer.Formatting = Formatting.Indented;
            xmlDoc.Save(writer);
            StreamReader sr = new StreamReader(stream, System.Text.Encoding.UTF8);
            stream.Position = 0;
            string xmlString = sr.ReadToEnd();
            sr.Close();
            stream.Close();
            return xmlString;
        }
    }
}