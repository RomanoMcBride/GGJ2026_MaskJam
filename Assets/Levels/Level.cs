using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Mask Jam 2000/Level")]
public class Level : ScriptableObject
{
	public string levelName;
	public string levelID;
	public string levelFileName;
	public Texture2D levelPreviewImage;
}
