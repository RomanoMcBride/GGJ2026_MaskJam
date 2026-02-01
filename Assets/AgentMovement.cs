// MoveToClickPoint.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class AgentMovement : MonoBehaviour {
        NavMeshAgent agent;
        public GameObject player;
        public float maxSight = 10f;
        private int state = 0;
        public float followRadius = 10f;
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
        timeLeft -= Time.fixedDeltaTime;
            if (timeLeft <= 0)
            {   
                switch (state)
                {
                    case 0:
                        NavMeshHit hit;
                        Vector3 randomDirection = new Vector3(Random.Range(-25f, 25f), 0, Random.Range(-25f, 25f));
                        NavMesh.SamplePosition(randomDirection, out hit, 100, NavMesh.AllAreas);
                        targetDestination = hit.position;
                        break;
                    case 1:
                        NavMeshHit hit2;
                        NavMesh.SamplePosition(directedRandomWonder(), out hit2, 100, NavMesh.AllAreas);
                        targetDestination = hit2.position;
                        break;
                        }
                timeLeft = Random.Range(5f, 10f);
                state = (state > 0) ? state - 1 : 0;
            }

            switch (state)
                {
                    case 2:
                        targetDestination = player.transform.position;
                        break;
                    case 3:
                        break;
                }

            // print(  state);

            //Set Animation Stuff Here





        agent.SetDestination(targetDestination);
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
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("ViewCone", "Agent");
        if(Physics.Raycast(transform.position, direction, out hit, Vector3.Distance(transform.position, player.transform.position), ~mask))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
            print(hit.collider.gameObject.name);
            if(hit.collider.gameObject == player)
            {
                return true;
            }
        }
        return false;
    }

    public bool differentColor()
    {
        Color agentColor = GetComponent<Renderer>().material.color;
        Color playerColor = player.GetComponent<Renderer>().material.color;
        return agentColor != playerColor;
    }

    public void stopIdle(float proportion)
    {
        if (notBehindWall())
        {
            switch (proportion)
            {
                case float p when (p > 0.85f):
                    state = 1;
                    break;
                case float p when (p <= 0.85f && p >= 0.15f):
                    state = 2;
                    break;
                case float p when (p < 0.15f):
                    state = 3;
                    break;
            }
        }
        else
        {
            state = 0;
        }
    }
    
}