using System;
using UnityEngine;

public class MaskPickup : MonoBehaviour
{
	[Header("configuration")]
	public MaskType maskType;
	[Header("references")]
	public MaskPickupMask mask;
	public MaskPickupBase pickupBase;
	
	private void Start()
	{
		if (!maskType)
		{
			Debug.LogWarning("Pickup doesn't have a mask type!");
		}
		else
		{
			UpdateMaskVisuals();
		}
		
	}
	
	private void OnValidate()
	{
		UpdateMaskVisuals();
	}

	private void UpdateMaskVisuals()
	{
			
		//set visuals to match mask type
		if (mask)
		{
			mask.SetColor(maskType.maskColor);
		}

		if (pickupBase)
		{
			pickupBase.SetColor(maskType.maskColor);
		}
	}
	
	private void OnTriggerEnter(Collider other)
    {
	    if (other.name == "Player")
	    {
			PlayerState ps = other.GetComponent<PlayerState>(); 
			ps.PickUpMask(maskType); 
	    }
    }
}
