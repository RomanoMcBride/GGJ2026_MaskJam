// MoveToClickPoint.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;

    public class AgentMovement : MonoBehaviour {
        public Animator animator;
        public GameObject player;

        private NavMeshAgent agent;
        private int state = 0;
        private float followRadius = 5f;
        private float timeLeft = 0f;
        private float wonderSpeed = 2f;
        private float surprisedSpeed = 3f;
        private float chaseSpeed = 4f;

        private Vector3 targetDestination;

        void Start() {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            agent = GetComponent<NavMeshAgent>();
        }

    void FixedUpdate()
    {
        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft <= 0)
        {   
            timeLeft = Random.Range(3, 7);
            state = (state > 0) ? state - 1 : 0;
            switch (state)
            {
                case 0:
                    NavMeshHit hit;
                    Vector3 randomDirection = new Vector3(Random.Range(-25f, 25f), 0, Random.Range(-25f, 25f));
                    NavMesh.SamplePosition(randomDirection, out hit, 100, NavMesh.AllAreas);
                    targetDestination = hit.position;
                    agent.speed = wonderSpeed;
                    break;
                case 1:
                    targetDestination = player.transform.position + Vector3.Normalize(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))) * followRadius;
                    agent.speed = surprisedSpeed;
                    break;
                    }
        }    

        if(state == 2)
        {
            targetDestination = player.transform.position;
            agent.speed = chaseSpeed;
        }

        //Set Animation Stuff Here
        print(agent.velocity.magnitude);
        if (targetDestination == transform.position && agent.velocity.magnitude < 0.1f)
        {
            animator.SetFloat("speed", 0);
            return;
        }
        switch (state){
            case 0:
                animator.SetFloat("speed", wonderSpeed);
                animator.SetBool("chasing", false);
                animator.SetBool("surprised", false);
                break;
            case 1:
                animator.SetFloat("speed", surprisedSpeed);
                animator.SetBool("chasing", false);
                animator.SetBool("surprised", true);
                break;
            case 2:
                animator.SetFloat("speed", chaseSpeed);
                animator.SetBool("chasing", true);
                animator.SetBool("surprised", false);
                break;
        }

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
        if(Physics.Raycast(transform.position, direction, out hit, Vector3.Distance(transform.position, player.transform.position)))
        {
            Debug.DrawRay(transform.position, direction * hit.distance, Color.red);
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
        if (proportion < 0.15f)
        {
            // Caught the player
            return;
        }
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
            }
        }
        else
        {
            state = 0;
        }
    }
    
}