using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "MaskType", menuName = "Mask Jam 2000/Mask Type")]

public class MaskType : ScriptableObject
{
	[FormerlySerializedAs("name")] public string maskName;
	public Color maskColor;
}
