using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMake;
using LevelData;
using System.Xml.Serialization;
using System.IO;


namespace DataMake
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToWrite = "/data.xml";
            List<Level> levels = new List<Level>();
            float speed = 10;

            for ( short i = 0; i < 15; i ++)
            {
                Level l = new Level();
                l.name = "Level " + i;
                if (i < 5)
                    l.noOfCharacters = 1;
                else
                if (i < 10)
                    l.noOfCharacters = 2;
                else
                    l.noOfCharacters = 3;

                switch (i)
                {
                    case 0:
                    default:
                        l.pathOfLandmark = string.Empty;
                        break;
                }

                l.speed = speed;
                speed += (i + 1) * 2.5f;

                l.weapon = Weapon.None;

                levels.Add(l);
            }

            FileStream fs = new FileStream(Environment.CurrentDirectory + pathToWrite, FileMode.OpenOrCreate & FileMode.Append);

            XmlSerializer xmls = new XmlSerializer(typeof(List<Level>));

            xmls.Serialize(fs, levels);

            fs.Close();
        }
    }
}
