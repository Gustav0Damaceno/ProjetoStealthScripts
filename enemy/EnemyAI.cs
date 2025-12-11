using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyDetection))]
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    EnemyDetection detection;
    Transform player;

    enum State { Patrolling, Investigating, Chasing, Attacking }
    State state;

    [Header("Ataque")]
    public float attackDistance = 2f;
    public float attackCooldown = 1f;
    float lastAttack;

    public float dano = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponent<EnemyDetection>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        state = State.Patrolling;
    }

    void Update()
    {
        switch (state)
        {
            case State.Patrolling:
                Patrol();
                break;

            case State.Investigating:
                Investigate();
                break;

            case State.Chasing:
                Chase();
                break;

            case State.Attacking:
                Attack();
                break;
        }

        StateMachineUpdate();
    }

    void StateMachineUpdate()
    {
        if (detection.detection > 0 && detection.detection < 100)
            state = State.Investigating;

        if (detection.isDetectingPlayer)
            state = State.Chasing;

        if (Vector3.Distance(transform.position, player.position) < attackDistance)
            state = State.Attacking;

        if (detection.detection <= 0)
            state = State.Patrolling;
    }

    void Patrol()
    {
        // você pode colocar waypoint aqui depois
        agent.isStopped = true;
    }

    void Investigate()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void Chase()
    {
        agent.isStopped = false;
        agent.SetDestination(player.position);
    }

    void Attack()
    {
        agent.isStopped = true;

        transform.LookAt(player);

        if (Time.time - lastAttack > attackCooldown)
        {
            lastAttack = Time.time;

            player.GetComponent<PlayerStats>().LevarDano(dano);
            Debug.Log("INIMIGO ATACOU O PLAYER");
        }
    }
}
