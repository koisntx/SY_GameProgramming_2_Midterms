using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Enemy Attributes")]
    [SerializeField] protected Transform target;

    protected virtual void Update()
    {
        
        Vector3 directionToTarget = target.position - transform.position;

        if (directionToTarget.magnitude > 0.1f)
        {
            Vector3 normalizedDirection = directionToTarget.normalized;
            transform.position += normalizedDirection * moveSpeed * Time.deltaTime;
        }
    }

    [Header("Base Actor Attributes")]
    [SerializeField] protected float maxHealth = 10f;
    protected float currentHealth;
    [SerializeField] protected float moveSpeed = 3f;
    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has been vanquished from their mortal shell");
        Destroy(gameObject);
    }
}