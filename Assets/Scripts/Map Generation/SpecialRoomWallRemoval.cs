using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRemoval : MonoBehaviour
{
    [Tooltip("How far to check for overlapping walls.")]
    public float overlapCheckRadius = 0.1f;

    private void Start()
    {
        DetectAndRemoveOverlappingWalls();
    }

    private void OnDrawGizmos()
    {
        // Draw a red sphere in the Scene view to visualize the overlap check radius.
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapCheckRadius);
    }

    private void DetectAndRemoveOverlappingWalls()
    {
        // Get all overlapping colliders within a small radius.
        Collider[] overlaps = Physics.OverlapSphere(transform.position, overlapCheckRadius);

        foreach (Collider overlap in overlaps)
        {
            // Check if the overlapping object is a wall.
            if (overlap.gameObject.CompareTag("Wall") && overlap.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                if (overlap.gameObject != gameObject)
                {
                    // Check if the walls form a valid pair.
                    if (IsValidWallPair(gameObject.name, overlap.gameObject.name))
                    {
                        // Destroy the overlapping wall.
                        Destroy(overlap.gameObject);

                        // Destroy this wall.
                        Destroy(gameObject);

                        // Exit to avoid further processing after destruction.
                        return;
                    }
                }
            }
        }
    }

    private bool IsValidWallPair(string wallA, string wallB)
    {
        // Define valid pairs.
        var validPairs = new Dictionary<string, string>
        {
            { "NXWall", "XWall" },
            { "NZWall", "ZWall" }
        };

        // Check for a valid pair in both directions.
        return (validPairs.ContainsKey(wallA) && validPairs[wallA] == wallB) ||
               (validPairs.ContainsKey(wallB) && validPairs[wallB] == wallA);
    }
}

