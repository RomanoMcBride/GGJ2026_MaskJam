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

        private Vector3 targetDestination;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            createTargetDestination();
        }

        void Update()
    {
        if (following)
        {
            followPlayer();
        }
        else
        {
            randomMovement();
        }
    }

    void randomMovement()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            createTargetDestination();
            timeLeft = waitTime;
        }
        agent.destination = targetDestination;
    }
    void createTargetDestination()
    {
            float radius = Random.Range(minRadius, maxRadius);
            float angle = (Random.Range(0, 2*Mathf.PI));
            float xOffset = radius * Mathf.Cos(angle);
            float zOffset = radius * Mathf.Sin(angle);
            targetDestination = player.transform.position + new Vector3(xOffset, 0, zOffset);
    }
        void followPlayer()
    {
        agent.destination = player.transform.position;
    }
}