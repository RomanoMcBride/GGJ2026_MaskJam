using UnityEngine;

public class PlayerState : MonoBehaviour
{
	public bool wearingMask;
	public MaskType currentMaskType;
	public SkinnedMeshRenderer maskMeshRenderer;
	public GameObject nakedPlayer;
	public GameObject maskedPlayer;
	private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    //player starts naked, without mask
        nakedPlayer.SetActive(true);
        maskedPlayer.SetActive(false);
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
	    
	    //switch to the masked player model
	    nakedPlayer.SetActive(false);
	    maskedPlayer.SetActive(true);
	    
    }
}
