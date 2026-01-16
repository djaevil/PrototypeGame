using UnityEngine;

public class MonsterVisionCheck : MonoBehaviour
{
    public PlayerVision playerVision;
    public float lookThreshold = 0.8f;

    public bool PlayerLookingAtMonster()
    {
        Vector3 toMonster = (transform.position - playerVision.Origin).normalized;
        float dot = Vector3.Dot(playerVision.Forward, toMonster);

        return dot > lookThreshold;
    }

    public bool MonsterIsVisibleToPlayer()
    {
        return playerVision.IsPointInVision(transform.position);
    }
}
