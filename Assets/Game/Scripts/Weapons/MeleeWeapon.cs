using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : TriggerDamage, IWeapon
{
    public bool IsAttacking { get; private set; }

    [SerializeField] float attackTime = 0.23f;

    private void Awake()
    {
        gameObject.SetActive(false);
        IsAttacking = false;
    }

    public void Attack()
    {
        if (!IsAttacking)
        {
            //Isso fará com que a corrotina tenha que acabar para que outro ataque possa ser iniciado
            IsAttacking = true;
            gameObject.SetActive(true);
            StartCoroutine(PerformAttack());
        }

    }

    public IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(attackTime);
        gameObject.SetActive(false);
        IsAttacking = false;
    }
}
