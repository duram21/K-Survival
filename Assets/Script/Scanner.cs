using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public Collider2D[] targets;

    public Transform nearestTarget;

    void FixedUpdate()
    {
        targets = Physics2D.OverlapCircleAll(transform.position, scanRange, targetLayer);

        nearestTarget = GetNearest();
    }

Transform GetNearest()
{
    Transform result = null;
    float diff = Mathf.Infinity;

    foreach (Collider2D target in targets)
    {
        if (target == null || !target.gameObject.activeInHierarchy || !target.enabled) continue;
            Monster monster = target.GetComponent<Monster>();
            if (monster == null || !monster.isLive)
                continue;


            float curDiff = Vector2.Distance(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(target.transform.position.x, target.transform.position.y)
        );

        if (curDiff < diff)
        {
            diff = curDiff;
            result = target.transform;
        }
    }

    return result;
}

void OnDrawGizmos()
{
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, scanRange);
}

}
