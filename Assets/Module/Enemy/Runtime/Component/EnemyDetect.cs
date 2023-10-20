using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyDetect : MonoBehaviour
{

    public float bodyRaycastDistance = 1.0f;
    public LayerMask layerMask;
    private Collider2D collider2D;

    private GameObject target;
    public GameObject Target => target;

    public Subject<Unit> FindTarget = new Subject<Unit>();
    public Subject<Unit> LostTarget = new Subject<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        BodyDetectionRay();
        TrackTarget();
    }

    public void HeadDetectionRay()
    {

    }

    public void BodyDetectionRay()
    {
        if (target != null)
        {
            return;
        }

        // 获取角色的位置和朝向
        Vector2 center = collider2D.bounds.center;
        float offset = collider2D.bounds.size.x * 0.5f;
        Vector2 position = (transform.lossyScale.x > 0) ? new Vector2(center.x + offset,center.y) : new Vector2(center.x - offset, center.y);

        Vector2 direction = (transform.lossyScale.x>0)?transform.right:(transform.right * -1); // 这里假设角色朝向是右边

        // 使用物理射线检测前方碰撞体
        RaycastHit2D hit = Physics2D.Raycast(position, direction, bodyRaycastDistance, layerMask);
        Debug.DrawRay(position, direction * bodyRaycastDistance,Color.green);
        // 如果射线击中了碰撞体
        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
            FindTarget.OnNext(Unit.Default);
            // 在这里可以处理碰撞体被检测到的情况
            Debug.Log("碰撞体被检测到：" + hit.collider.name);
        }
    }

    public void FootDetectionRay()
    {

    }

    public void TrackTarget()
    {
        if (target == null)
            return;
        if (Vector2.Distance(target.transform.position, transform.position) > 5f)
        {
            target = null;
            LostTarget.OnNext(Unit.Default);
        }
    }
}
