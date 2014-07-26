using UnityEngine;
#if !UNITY_ANDROID
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        ObjectBuilderScript myScript = (ObjectBuilderScript)target;
        if(GUILayout.Button("Build"))
        {
            myScript.BuildObject();
        }

		if ( GUILayout.Button ( "Serialize " ))
		{
			myScript.SerializeObject();
		}
    }
}
#endif
