using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using MAIN_SETTINGS;
using System.IO;
using System.Collections.Generic;
using LevelData;
public class BinaryLoader : MonoBehaviour {
   public static Level LoadLevel(MAIN_SETTINGS.LEVEL_NUM levelNo)
    {
        XmlSerializer xmls = new XmlSerializer(typeof(List<Level>));
        string debug = string.Empty;
#if !UNITY_EDITOR && UNITY_ANDROID
        debug += @"sdcard/Android";
#endif
        debug += Application.dataPath + @"/Resources/data.xml";
        if (File.Exists(debug))
        {
            FileStream fs = new FileStream(debug, FileMode.Open);
            List<Level> lvlData = (List<Level>)xmls.Deserialize(fs);
            DebugPanel.AddText("Loaded" + fs.Name, true);
            fs.Close();
            fs.Dispose();
            return lvlData[(int)levelNo];
        }
        else
        {
            DebugPanel.AddText("File Not found!" + debug, true);
        }


        //Fallback

        {
            TextAsset tx = Resources.Load<TextAsset>("/data.xml");
            if ( tx == null)
            {
                DebugPanel.AddText("Fallback load failed", true);
                return null;
            }
            MemoryStream ms = new MemoryStream(tx.bytes);
            try
            {
                var t = xmls.Deserialize(ms);
                if ( t == null )
                {
                    DebugPanel.AddText("Fallback Serialization failed", true);
                    return null;
                } 
                DebugPanel.AddText("Fallback success", true);
              
            }
            catch(System.Exception e)
            {
                DebugPanel.AddText("Fallback Exception failed", true);
            }
            ms.Close();
        }
        return null;
    }
}
