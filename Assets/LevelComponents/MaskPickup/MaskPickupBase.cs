using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MaskPickupBase : MonoBehaviour
{
	private MeshRenderer meshRenderer;
    void Start()
    {
	    meshRenderer = GetComponent<MeshRenderer>();
    }

    public void setFill(float fillValue)
    {
	    Material[] materials = meshRenderer.materials;

	    materials[1].SetFloat("_Fill", fillValue);
	    
	    meshRenderer.materials = materials;
    }

    public void SetColor(Color color)
    {
	    Material[] materials = meshRenderer.materials;

	    materials[1].color = color;

	    meshRenderer.materials = materials;
    }
}
