using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAnimationControllerScript : MonoBehaviour
{
    private int attackIndex;
    private int attackInterval;
    private const int NOT_ATTACK_FLAG = -1;

    private Animator animator;

    void Start()
    {
        attackIndex = Random.Range(0, 3);
        attackInterval = Random.Range(2, 9);

        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(AttackLoop());
    }

    private IEnumerator AttackLoop()
    {
        animator.SetInteger("AttackIndex", NOT_ATTACK_FLAG);
        yield return new WaitForSeconds(attackInterval);
        Attack();
    }

    public void ArrowHit()
    {
        animator.SetTrigger("ArrowHit");
    }

    public void SwordHit()
    {
        animator.SetTrigger("SwordHit");
    }

    public void Die()
    {
        animator.SetTrigger("Die");
    }

    private void Attack()
    {
        animator.SetInteger("AttackIndex", attackIndex);
    }
}
