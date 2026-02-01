using UnityEngine;

public class MaskPickupMask : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	public void SetColor(Color color)
	{
		Material[] materials;
		#if UNITY_EDITOR
		if (!Application.isPlaying)
		{
			materials = meshRenderer.sharedMaterials;

			if (materials[0])
			{
				materials[0].color = color;
			}

			meshRenderer.sharedMaterials = materials;
			return;
		}
		#endif
		
		materials = meshRenderer.materials;

		materials[0].color = color;

		meshRenderer.materials = materials;
	}
}
