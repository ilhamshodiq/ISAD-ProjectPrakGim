using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnabled;

    [SerializeField]
    private AudioSource hitSoundEffect;

    [SerializeField]
    private float inputTimer,
        attack1Radius,
        attack1Damage;

    [SerializeField]
    private Transform attack1HitBoxPos;

    [SerializeField]
    private LayerMask WhatIsDamageable;

    private bool gotInput,
        isAttacking,
        isFirstAttack;

    private float lastInputTime = Mathf.NegativeInfinity;

    private AttackDetails attackDetails;

    private Animator anim;

    private PlayerController PC;
    private PlayerStats PS;

    private void Start()
    {
         hitSoundEffect.Stop();
        anim = GetComponent<Animator>();
        anim.SetBool("canAttack", combatEnabled);
        PC = GetComponent<PlayerController>();
        PS = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        CheckCombatInput();
        CheckAttacks();
    }

    private void CheckCombatInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (combatEnabled)
            {
                gotInput = true;
                lastInputTime = Time.time;
            }
            hitSoundEffect.Play();
        }
    }

    private void CheckAttacks()
    {
        if (gotInput)
        {
            //attack1
            if (!isAttacking)
            {
                gotInput = false;
                isAttacking = true;
                isFirstAttack = !isFirstAttack;
                anim.SetBool("attack1", true);
                anim.SetBool("firstAttack", isFirstAttack);
                anim.SetBool("isAttacking", isAttacking);
            }
        }
        if (Time.time >= lastInputTime + inputTimer)
        {
            //wait next input
            gotInput = false;
        }
    }

    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(
            attack1HitBoxPos.position,
            attack1Radius,
            WhatIsDamageable
        );

        attackDetails.damageAmount = attack1Damage;
        attackDetails.position = transform.position;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
            //Instantiate hit particle
        }
    }

    private void FinishAttack1()
    {
        isAttacking = false;
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("attack1", false);
    }

    private void Damage(AttackDetails attackDetails)
    {
        int direction;

        PS.DescreaseHealth(attackDetails.damageAmount);


        if (attackDetails.position.x < transform.position.x)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        PC.Knockback(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
    }
}
