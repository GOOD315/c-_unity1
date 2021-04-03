using System.Globalization;
using System.IO;
using System.Xml;
using Code.Buffs;
using UnityEngine;
using UnityEngine.UIElements;

namespace Code.SaveData
{
    public sealed class XMLData : IData<SavedData>
    {
        public void Save(SavedData Data, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("SaveData");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Player");
            element.SetAttribute("value", Data.Name);
            rootNode.AppendChild(element);

            var element2 = xmlDoc.CreateElement("Position");
            element2.SetAttribute("posX", Data.Position.X.ToString());
            element2.SetAttribute("posY", Data.Position.Y.ToString());
            element2.SetAttribute("posZ", Data.Position.Z.ToString());
            element.AppendChild(element2);

            element = xmlDoc.CreateElement("TrapsList");
            element.SetAttribute("Length", Data.currentActiveTrapsList.Length.ToString());
            rootNode.AppendChild(element);

            foreach (GameObject trap in Data.currentActiveTrapsList)
            {
                element2 = xmlDoc.CreateElement("Trap");
                element2.SetAttribute("Type", trap.GetComponent<Trap>().trapType.ToString());
                element2.SetAttribute("posX", trap.transform.position.x.ToString());
                element2.SetAttribute("posY", trap.transform.position.y.ToString());
                element2.SetAttribute("posZ", trap.transform.position.z.ToString());
                element.AppendChild(element2);
            }

            element = xmlDoc.CreateElement("BuffsList");
            element.SetAttribute("Lenght", Data.playerBuffs.Count.ToString());
            rootNode.AppendChild(element);

            foreach (TrapBuff buff in Data.playerBuffs)
            {
                element2 = xmlDoc.CreateElement("Buff");
                element2.SetAttribute("Type", buff.BuffType.ToString());
                element2.SetAttribute("Timer", buff.Timer.ToString());
                element.AppendChild(element2);
            }

            xmlDoc.Save(path);
        }

        public SavedData Load(string path = "")
        {
            var result = new SavedData();
            if (!File.Exists(path)) return result;

            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Player";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                        continue;
                    }

                    key = "Trap";
                    if (reader.IsStartElement(key))
                    {
                        var x = int.Parse(reader.GetAttribute("posX") ?? string.Empty);
                        var y = int.Parse(reader.GetAttribute("posY") ?? string.Empty);
                        var z = int.Parse(reader.GetAttribute("posZ") ?? string.Empty);
                        result.currentActiveTrapsList.AddTrap(reader.GetAttribute("Type"), x, y, z);
                        continue;
                    }

                    key = "Buff";
                    if (reader.IsStartElement(key))
                    {
                        var type = reader.GetAttribute("Type");
                        var timer = reader.GetAttribute("Timer");

                        result.AddBuff(type, timer);
                    }
                }
            }

            return result;
        }
    }
}