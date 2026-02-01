using System;
using UnityEngine;

public class MaskPickup : MonoBehaviour
{
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
			MeshRenderer mr = GetComponent<MeshRenderer>();
			//set visuals to match mask type
			mask.SetColor(maskType.maskColor);
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
