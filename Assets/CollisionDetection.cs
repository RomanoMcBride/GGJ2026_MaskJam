using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public GameObject player;
    public GameObject agent;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Called when the Collider other enters the trigger
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            float proportion = Vector3.Distance(transform.position, player.transform.position) / Mathf.Sqrt(transform.localScale.x * transform.localScale.x + transform.localScale.z * transform.localScale.z);
            agent.GetComponent<AgentMovement>().stopIdle(proportion);
        }
    }
}