using UnityEngine;

public class PlayerState : MonoBehaviour
{
	public bool wearingMask;
	public MaskType currentMaskType;
	public SkinnedMeshRenderer maskMeshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void PickUpMask(MaskType maskType)
    {
	    Debug.Log("Picking up mask: " + maskType );
	    currentMaskType = maskType;
	    //change color of mask
	    Material[] materials = maskMeshRenderer.materials;

	    materials[1].color = maskType.maskColor;
	    
	    maskMeshRenderer.materials = materials;
	    
    }
}
