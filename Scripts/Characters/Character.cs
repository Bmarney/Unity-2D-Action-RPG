using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Character : MonoBehaviour, IDamagable
{
    // abstract means character must be extended from and cant be attatched to a game object
    
    public string displayName;//character name
    public int curHP;
    public int maxHP;
    public enum Team
    {
        Player,
        Enemy
    }
    [SerializeField] protected Team team;

    [Header("Audio")]
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip hitSFX;

    public event UnityAction onTakeDamage;
    public event UnityAction onHeal;

     public virtual void Heal(int healAmount)
    {
        curHP += healAmount;
        if (curHP>maxHP)
        {
            curHP = maxHP;
        }
        onHeal?.Invoke();
    }

    public virtual void TakeDamage(int damageToTake)
    {
        curHP -= damageToTake;

        audioSource.PlayOneShot(hitSFX);

        onTakeDamage?.Invoke();//the questionmark calls this if it has something. ex an action from the unity event

        if (curHP <= 0)
        {
            Die();
        }

    }

    public virtual void Die() // virtual makes this function over-ridable

    {
        
    }

    public Team GetTeam()
    {
        return team;
    }
}
