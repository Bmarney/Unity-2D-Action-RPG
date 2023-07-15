using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    // the enemy will either be melee or ranged so this class can also be abstract and unused directly on game objects
    
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    protected State curState;

    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float chaseDistance;

    protected GameObject target;

    protected float lastAttackTime;
    protected float targetDistance;

    [Header("Components")]
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        target = FindObjectOfType<Player>().gameObject;
    }

    protected virtual void Update()
    {
        targetDistance = Vector2.Distance(transform.position, target.transform.position);

        switch (curState)
        {
            case State.Idle: IdleUpdate(); break;
            case State.Chase: ChaseUpdate(); break;
            case State.Attack: AttackUpdate(); break;
        }

        spriteRenderer.flipX = (GetTargetDirection().x < 0);
    }

    void ChangeState(State newState)
    {
        curState = newState;
    }

    void IdleUpdate()
    {
        if (targetDistance <= chaseDistance)
        {
            ChangeState(State.Chase);
        }
    }

    void ChaseUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        
        if (InAttackRange())
        {
            ChangeState(State.Attack);
        }
        else if (targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }
    }

    void AttackUpdate()
    {
        if (targetDistance > chaseDistance)
        {
            ChangeState(State.Idle);
        }
        else if (!InAttackRange())
        {
            ChangeState(State.Chase);
        }
        if (CanAttack())
        {
            lastAttackTime = Time.time;
            AttackTarget();
        }
    }

    public override void Die()
    {
        DropItems();
        Destroy(gameObject);
    }

    protected Vector2 GetTargetDirection()
    {
        return (target.transform.position - transform.position).normalized;
    }

    protected void DropItems()
    {

    }

    protected virtual void AttackTarget()
    {

    }

    protected virtual bool CanAttack()
    {
        return false;
    }

    protected virtual bool InAttackRange()
    {
        return false;
    }
}
