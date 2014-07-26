using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Serializable
{
    public class SerializableGameObjectWrapper : System.Object
    {
        public static System.Collections.Generic.List<SerializableGameObject> _obj = new System.Collections.Generic.List<SerializableGameObject>();

        public static void serialize(List<GameObject> list)
        {
            System.Xml.Serialization.XmlSerializer xmls =
                new System.Xml.Serialization.XmlSerializer(typeof(List<SerializableGameObject>));

            System.IO.FileStream fs = new System.IO.FileStream("C://Projects/xml", System.IO.FileMode.OpenOrCreate);
            foreach (var t in list)
            {
                SerializableGameObject s = new SerializableGameObject();
                s.transform = new SerializableTransform()
                {
                    position = ObjConverter.convertFromNative(t.transform.position),
                    rotation = ObjConverter.convertFromNative(t.transform.rotation.eulerAngles),
                    scale = ObjConverter.convertFromNative(t.transform.localScale)
                };
                s.path = "afasf";
                s.tag = "afs";

                _obj.Add(s);
            }

            xmls.Serialize(fs, _obj);

            fs.Close();
        }

        public static List<SerializableGameObject> read()
        {
            System.Xml.Serialization.XmlSerializer xmls =
                new System.Xml.Serialization.XmlSerializer(typeof(List<SerializableGameObject>));

            System.IO.FileStream fs = new System.IO.FileStream("C://Projects/xml", System.IO.FileMode.OpenOrCreate);
            List<SerializableGameObject> o = null;

            o = (List<SerializableGameObject>)xmls.Deserialize(fs);
            fs.Close();
            return o;
        }



        public class SerializableGameObject : System.Object
        {
            public string path;
            public SerializableTransform transform;
            public string tag;

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
