using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaskPickupBase : MonoBehaviour
{
	public MeshRenderer meshRenderer;
    public void SetFill(float fillValue)
    {
	    //Debug.Log("setting fill to" +  fillValue);
	    Material[] materials = meshRenderer.materials;

	    materials[1].SetFloat("_Fill", fillValue);
	    
	    meshRenderer.materials = materials;
    }

    public void SetColor(Color color)
    {
	    Material[] materials;
		#if UNITY_EDITOR
	    if (!Application.isPlaying)
	    {
		    materials = meshRenderer.sharedMaterials;

		    if (materials[1])
		    {
			    materials[1].color = color;
		    }

		    meshRenderer.sharedMaterials = materials;
		    return;
	    }
		#endif
	    
	    materials = meshRenderer.materials;

	    
	    materials[1].color = color;

	    meshRenderer.materials = materials;
    }
}
