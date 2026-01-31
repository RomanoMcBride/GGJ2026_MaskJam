// MoveToClickPoint.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class AgentMovement : MonoBehaviour {
        NavMeshAgent agent;
        public GameObject player;
        public float maxSight = 10f;
        private int state = 0;
        public float followRadius = 20f;
        private Ray[] feildOfView;
        private float timeLeft = 0f;

        private Vector3 targetDestination;

        void Start() {
            player = GameObject.Find("Player");
            agent = GetComponent<NavMeshAgent>();
            targetDestination = new Vector3(0,0,0);
        }

    void FixedUpdate()
    {
        if (state == 0 || state == 1)
        {
            timeLeft -= Time.fixedDeltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = Random.Range(5f, 10f);
                targetDestination = (state == 0) ? new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f)) : directedRandomWonder();
            }
        }
        else
        {
            targetDestination = player.transform.position;
        }
        //agent.SetDestination(targetDestination);
    }

    Vector3 directedRandomWonder()
    {
        float minRadius = followRadius;
        float maxRadius = followRadius + 10f;
        float radius = Random.Range(minRadius, maxRadius);
        float angle = Random.Range(0, 2 * Mathf.PI);
        float xOffset = radius * Mathf.Cos(angle);
        float zOffset = radius * Mathf.Sin(angle);
        return player.transform.position + new Vector3(xOffset, 0, zOffset);
    }

    public bool notBehindWall()
    {
        RaycastHit hit;
        Vector3 forwardDir = (transform.forward / transform.localScale.magnitude);
        for(int deg = -50; deg <= 50; deg += 1){
            Vector3 direction = Quaternion.Euler(0, deg, 0) * forwardDir;
            if(Physics.Raycast(transform.position, direction, out hit, maxSight) && hit.collider.gameObject == player){
                return true;
            }
        }
        return false;
    }

    public void stopIdle(float proportion)
    {
        print("Proportion: " + proportion);
        if (notBehindWall())
        {
            if (proportion < 0.5f)
            {
                state = 2;
            }
            else
            {
                state = 1;
            }
        }
        else
        {
            state = 0;
        }
        print("State: " + state);
    }
}