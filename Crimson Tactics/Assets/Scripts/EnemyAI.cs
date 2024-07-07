using UnityEngine;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GridManager gridManager;
    private Pathfinding pathfinding;
    private List<Vector2Int> currentPath;
    private int currentPathIndex = 0;
    private bool isMoving = false;
    public GameObject playerUnit;
    private Vector2Int nextTargetGridPosition;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>(); // Assuming Pathfinding is attached to the same GameObject as EnemyAI
        nextTargetGridPosition = gridManager.WorldToGridPosition(playerUnit.transform.position);
        FollowPlayer();
    }

    void Update()
    {
        if (isMoving)
        {
            if (currentPath == null || currentPath.Count == 0)
            {
                isMoving = false;
                return;
            }

            Vector3 targetPosition = gridManager.GetWorldPosition(currentPath[currentPathIndex]);
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            }
            else
            {
                currentPathIndex++;

                if (currentPathIndex >= currentPath.Count)
                {
                    isMoving = false;
                    nextTargetGridPosition = gridManager.WorldToGridPosition(playerUnit.transform.position);
                }
                else if (currentPathIndex >= currentPath.Count - 2)
                {
                    // Stop 2 tiles ahead
                    isMoving = false;
                    nextTargetGridPosition = gridManager.WorldToGridPosition(playerUnit.transform.position);
                }
            }
        }
        else
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        if (playerUnit == null)
        {
            Debug.LogError("Player unit reference is null.");
            return;
        }

        Vector2Int startPos = gridManager.WorldToGridPosition(transform.position);
        Vector2Int playerPos = gridManager.WorldToGridPosition(playerUnit.transform.position);

        // Update next target grid position if the player has moved significantly
        if (Vector2Int.Distance(startPos, nextTargetGridPosition) > 2)
        {
            nextTargetGridPosition = playerPos;
        }

        currentPath = pathfinding.FindPath(startPos, nextTargetGridPosition);

        if (currentPath != null && currentPath.Count > 0)
        {
            currentPathIndex = 0;
            isMoving = true;
        }
        else
        {
            Debug.LogWarning("No valid path found to player.");
            isMoving = false;
        }
    }
}
