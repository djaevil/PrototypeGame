using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [Header("Vision Settings")]
    public float viewDistance = 14f;
    [Range(30f, 120f)]
    public float viewAngle = 70f;

    [Header("References")]
    public Transform visionOrigin;

    public Vector3 Origin => visionOrigin.position;
    public Vector3 Forward => visionOrigin.forward;

    public bool IsPointInVision(Vector3 point)
    {
        Vector3 dir = point - Origin;
        float distance = dir.magnitude;
        if (distance > viewDistance)
            return false;

        float angle = Vector3.Angle(Forward, dir);
        if (angle > viewAngle * 0.5f)
            return false;

        if (Physics.Raycast(Origin, dir.normalized, distance))
            return false;

        return true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (!visionOrigin) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Origin, Origin + Forward * viewDistance);

        Vector3 left = Quaternion.Euler(0, -viewAngle / 2, 0) * Forward;
        Vector3 leftMiddle = Quaternion.Euler(0, -viewAngle / 4, 0) * Forward;
        Vector3 right = Quaternion.Euler(0, viewAngle / 2, 0) * Forward;
        Vector3 rightMiddle = Quaternion.Euler(0, viewAngle / 4, 0) * Forward;

        Gizmos.DrawLine(Origin, Origin + left * viewDistance);
        Gizmos.DrawLine(Origin, Origin + right * viewDistance);
        Gizmos.DrawLine(Origin,Origin + leftMiddle * viewDistance);
        Gizmos.DrawLine(Origin, Origin + rightMiddle * viewDistance);
    }
#endif
}