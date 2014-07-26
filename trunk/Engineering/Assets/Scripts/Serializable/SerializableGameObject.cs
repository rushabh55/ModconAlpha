using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Serializable
{
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
