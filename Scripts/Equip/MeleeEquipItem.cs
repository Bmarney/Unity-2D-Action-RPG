using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEquipItem : EquipItem
{
    [SerializeField] private LayerMask hitLayerMask;
    [SerializeField] private Animator anim;
    private float lastAttackTime;

    [SerializeField] private AudioClip swingSFX;

    public override void OnUse()
    {
        MeleeWeaponItemData i = item as MeleeWeaponItemData;
        if (Time.time - lastAttackTime < i.AttackRate)
            return;

        lastAttackTime = Time.time;

        //play attack animation
        anim.SetTrigger("Attack");

        //shoot a raycast forwards
        // if we hit anything in the right layer, damage it
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, i.Range, hitLayerMask);
        if (hit.collider != null)
        {
            IDamagable damagable = hit.collider.GetComponent<IDamagable>();

            if (damagable != null)
            {
                damagable.TakeDamage(i.Damage);
            }
        }


        //play sound effect
    }

}
