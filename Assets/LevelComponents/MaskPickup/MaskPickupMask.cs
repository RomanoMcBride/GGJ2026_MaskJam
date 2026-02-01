using UnityEngine;

public class MaskPickupMask : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	public void SetColor(Color color)
	{
		Material[] materials = meshRenderer.materials;

		materials[0].color = color;

		meshRenderer.materials = materials;
	}
}
