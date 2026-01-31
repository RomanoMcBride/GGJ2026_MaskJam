// MoveToClickPoint.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class MoveToClickPoint : MonoBehaviour {
        NavMeshAgent agent;
        public GameObject player;
        private float timeLeft = 10f;
        public float waitTime = 10f;
        public float maxSight = 10f;
        private bool following = false;

        private Ray[] feildOfView;

        private Vector3 targetDestination;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
            targetDestination = transform.position;
        }

        void Update()
    {
        if(following){
            followPlayer();
        }else
        {
            randomMovement();
        }
        agent.SetDestination(targetDestination);
        
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 forwardDir = (transform.forward / transform.localScale.magnitude);
        for(int deg = -50; deg <= 50; deg += 10){
            Vector3 direction = Quaternion.Euler(0, deg, 0) * forwardDir;
            if(Physics.Raycast(transform.position, direction, out hit, maxSight) && hit.collider.gameObject == player){
                if(hit.collider.gameObject == player)
                {
                    print("Player Spotted");
                    following = true;
                    break;
                } else {
                    print("No Player: " + hit.collider.gameObject.name);
                }
                break;
            } 
        }
    }

    // void OnDrawGizmos()
    //     {
    //         // Draw a yellow sphere at the transform's position
    //         Gizmos.color = Color.yellow;
    //         Gizmos.DrawLine(transform.position, transform.position + transform.forward * maxSight);
    //     }

    void randomMovement()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            targetDestination = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            timeLeft = waitTime;
        }
    }

    void directedRandomWonder(float minRadius, float maxRadius)
    {
        float radius = Random.Range(minRadius, maxRadius);
        float angle = Random.Range(0, 2 * Mathf.PI);
        float xOffset = radius * Mathf.Cos(angle);
        float zOffset = radius * Mathf.Sin(angle);
        targetDestination = player.transform.position + new Vector3(xOffset, 0, zOffset);

    }

    void followPlayer()
    {
        targetDestination = player.transform.position;
    }
}