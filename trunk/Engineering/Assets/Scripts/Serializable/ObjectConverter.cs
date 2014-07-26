using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Serializable
{
    public class ObjConverter
    {
        public static SerializableVector convertFromNative(float x, float y, float z)
        {
            SerializableVector s = new SerializableVector();
            s.x = x;
            s.y = y;
            s.z = z;
            return s;
        }

        public static SerializableVector convertFromNative(UnityEngine.Vector3 vec)
        {
            SerializableVector s = new SerializableVector();
            s.x = vec.x;
            s.y = vec.y;
            s.z = vec.z;
            return s;
        }

    }
}
