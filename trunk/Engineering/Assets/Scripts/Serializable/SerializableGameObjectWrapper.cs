using MAIN_SETTINGS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Serializable
{
    public class SerializableGameObjectWrapper : System.Object
    {

#if UNITY_ANDROID
            static string path = Application.persistentDataPath + "saveData.xml";
#else
            static string path = "C://Projects/save.xml";
#endif

        public static System.Collections.Generic.List<SerializableGameObject> _obj = new System.Collections.Generic.List<SerializableGameObject>();

        public static void serialize(List<GameObject> list)
        {
            System.Xml.Serialization.XmlSerializer xmls =
                new System.Xml.Serialization.XmlSerializer(typeof(List<SerializableGameObject>));
            string path = Settings.PERSISTENTDATAPATH + "data.dat";
            Debug.Log(path);
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
            DebugPanel.AddText(path);
            foreach (var t in list)
            {                
                SerializableGameObject s = new SerializableGameObject();
                s.transform = new SerializableTransform()
                {
                    position = ObjConverter.convertFromNative(t.transform.position),
                    rotation = ObjConverter.convertFromNative(t.transform.rotation.eulerAngles),
                    scale = ObjConverter.convertFromNative(t.transform.localScale)
                };
                s.name = t.name ;
                //s.objectType = t
                if (t.renderer != null)
                {
                    s.hasRenderer = true;
                }
                else
                {
                    s.hasRenderer = false;
                }
                if (s.name.Contains("Scene"))
                {
                    _obj.Add(s);
                }
            }

            xmls.Serialize(fs, _obj);

            fs.Close();
        }

        public static List<SerializableGameObject> read()
        {
            System.Xml.Serialization.XmlSerializer xmls =
                new System.Xml.Serialization.XmlSerializer(typeof(List<SerializableGameObject>));

            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate);
            if (!File.Exists(path))
                getData();
            List<SerializableGameObject> o = null;

            o = (List<SerializableGameObject>)xmls.Deserialize(fs);
            fs.Close();
            return o;
        }

        private static void getData()
        {
            
        }



        public class SerializableGameObject : System.Object
        {
            public string path;
            public SerializableTransform transform;
            public string parent;
            public string name;
            public List<SerializableGameObject> children;
//            public string objectType = typeof(UnityEngine.Object).SerializeToString();
            public bool hasRenderer = false;

            public SerializableGameObject()
            {
                transform = new SerializableTransform();
                transform.position = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));

                transform.rotation = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));
                transform.scale = ObjConverter.convertFromNative(new System.Random().Next(1, 100), new System.Random().Next(1, 100), new System.Random().Next(1, 100));

            }
        }

    }

}
