using UnityEngine;

public class MaskPickupMask : MonoBehaviour
{
	private MeshRenderer meshRenderer;
	void Start()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}
	

	public void SetColor(Color color)
	{
		Material[] materials = meshRenderer.materials;

		materials[0].color = color;

		meshRenderer.materials = materials;
	}
}
