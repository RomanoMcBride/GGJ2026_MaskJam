using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Level))]
public class LevelMetadataEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
        
		EditorGUILayout.Space();
        
		Level level = (Level)target;
        
		if (GUILayout.Button("Generate ID"))
		{
			
			level.levelID = Guid.NewGuid().ToString();
            
			EditorUtility.SetDirty(level);
		}
	}
}