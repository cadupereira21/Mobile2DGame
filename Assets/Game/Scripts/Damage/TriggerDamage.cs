using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
	[Min(0)]
	[SerializeField] int damage = 10;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IDamageable damageable = collision.GetComponent<IDamageable>();
		if (damageable != null)
		{
			damageable.TakeDamage(damage);
		}
	}
}
