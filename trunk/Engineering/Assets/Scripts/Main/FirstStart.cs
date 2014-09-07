using UnityEngine;
using System.Collections;
using System.IO;
using MAIN_SETTINGS;
using System.Collections.Generic;
using LevelData;
using System;
using System.Xml.Serialization;

public class FirstStart : MonoBehaviour {
    private string path;
	// Use this for initialization
	void Start () 
    {
        try
        {
            if (!File.Exists(Settings.dataFileName))
            {
                WriteToFile(); 
                DebugPanel.AddText(path + "\n" + File.Exists(Settings.dataFileName).ToString(), true);

            }
        }
        catch (Exception e)
        {
            DebugPanel.AddText(e.Message);
            return;
        }
        DebugPanel.AddText(path + "\n" + File.Exists(Settings.dataFileName).ToString(), true);
	}

    private void WriteToFile()
    {
        List<Level> levels = new List<Level>();
        float speed = 10;

        for (short i = 0; i < 15; i++)
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

        FileStream fs = new FileStream(Settings.dataFileName, FileMode.OpenOrCreate & FileMode.Append);
        path = fs.Name;
        XmlSerializer xmls = new XmlSerializer(typeof(List<Level>));

        xmls.Serialize(fs, levels);

        fs.Close();
    }	
}
