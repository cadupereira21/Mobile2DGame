using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(CharacterFacing2D))]
[RequireComponent(typeof(IDamageable))]
public class EnemyAIController : MonoBehaviour
{
    CharacterMovement2D enemyMovement;
    CharacterFacing2D enemyFacing;
    IDamageable damageable;

    [SerializeField] TriggerDamage damager;
    
    private Vector2 movementInput;

    public Vector2 MovementInput
    {
        get => movementInput;
        // value é como se fosse o parâmetro de um SetMovementInputX(float x);
        set { movementInput = new Vector2(Mathf.Clamp(value.x, -1, 1), Mathf.Clamp(value.y, -1, 1)); }
    }

    private bool isChasing;

    public bool IsChasing { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        enemyMovement = GetComponent<CharacterMovement2D>();
        enemyFacing = GetComponent<CharacterFacing2D>();
        damageable = GetComponent<IDamageable>();

        damageable.DeathEvent += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement.ProcessMovementInput(movementInput);
        enemyFacing.UpdateFacing(movementInput);
    }

    private void OnDestroy()
    {
        if(damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }

    private void OnDeath()
    {
        enabled = false;
        enemyMovement.StopImmediately();
        damager.gameObject.SetActive(false); // desabilita nossa capacidade de atacar
        Destroy(gameObject, 0.7f);
    }
}
