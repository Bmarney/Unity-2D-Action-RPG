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

        //shoot a raycast forwards
        // if we hit anything in the right layer, damage it
        //play sound effect
    }

}
