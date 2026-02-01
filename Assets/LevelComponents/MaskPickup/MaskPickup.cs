using System;
using UnityEngine;

public class MaskPickup : MonoBehaviour
{
	[Header("configuration")]
	public MaskType maskType;

	public float respawnTime = 3.0f;
	//status
	private float lastPickupTime;
	private bool hasMaskAvailable;
	
	[Header("references")]
	public MaskPickupMask mask;

	public GameObject maskObject;
	public MaskPickupBase pickupBase;
	public Animator animator;
	
	private void Start()
	{
		if (!maskType)
		{
			Debug.LogWarning("Pickup doesn't have a mask type!");
		}
		else
		{
			UpdateMaskVisuals();
			MakeMaskAvailable();
		}
		
	}

	void Update()
	{
		if (!hasMaskAvailable)
		{
			if (Time.time - lastPickupTime > respawnTime)
			{
				MakeMaskAvailable();
			}
		}
	}

	void MakeMaskAvailable()
	{
		hasMaskAvailable = true;
		animator.SetBool("hasMask", true);
	}
	
	void MakeMaskUnavailable()
	{
		hasMaskAvailable = false;
		animator.SetBool("hasMask", false);

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
	    if (hasMaskAvailable)
	    {
		    if (other.name == "Player")
		    {
			    PlayerState ps = other.GetComponent<PlayerState>();
			    lastPickupTime = Time.time;
			    ps.PickUpMask(maskType);
			    MakeMaskUnavailable();
		    }
	    }
    }
}
