// MoveToClickPoint.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class MoveToClickPoint : MonoBehaviour {
        NavMeshAgent agent;
        public GameObject player;
        public float minRadius = 10;
        public float maxRadius = 100;
        public float waitTime = 10f;
        public bool following = false;
        private float timeLeft = 10f;
        public float maxSight = 10f;

        private Ray[] feildOfView;

        private Vector3 targetDestination;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Player");
            createTargetDestination();
        }

        void Update()
    {
        
        
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
                } else {
                    print("No Player: " + hit.collider.gameObject.name);
                }
                break;
            } 
        }
    }

    void OnDrawGizmos()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * maxSight);
        }

    void randomMovement()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            createTargetDestination();
            timeLeft = waitTime;
        }
    }
    void createTargetDestination()
    {
        // Mathf.random()  
        //targetDestination = player.transform.position + new Vector3(xOffset, 0, zOffset);
    }
        void followPlayer()
    {
        targetDestination = player.transform.position;
    }
}