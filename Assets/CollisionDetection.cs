using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public GameObject player;
    public AgentMovement agentMovement;
    void Start()
    {
        player = GameObject.Find("Player");
        agentMovement = GetComponentInParent<AgentMovement>();
    }

    // Called when the Collider other enters the trigger
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            float proportion = Vector3.Distance(transform.position, player.transform.position) / Mathf.Sqrt(transform.localScale.x * transform.localScale.x + (transform.localScale.z * transform.localScale.z)/4f);
            agentMovement.stopIdle(proportion);
        }
    }
}