using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Vector2Int gridPosition;
	public float moveSpeed = 2f;
	private bool isMoving = false;
	private Pathfinding pathfinding;

	void Start()
	{
		pathfinding = FindObjectOfType<Pathfinding>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !isMoving)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				if (hit.collider.CompareTag("Tile"))
				{
					TileInfo tile = hit.collider.GetComponent<TileInfo>();
					if (!tile.tileHasObstacle)
					{
						List<Vector2Int> path = pathfinding.FindPath(gridPosition, new Vector2Int(tile.x, tile.y));
						if (path != null)
						{
							StartCoroutine(MoveAlongPath(path));
						}
					}
				}
			}
		}
	}

	private IEnumerator MoveAlongPath(List<Vector2Int> path)
	{
		isMoving = true;

		foreach (Vector2Int targetPosition in path)
		{
			Vector3 targetWorldPosition = new Vector3(targetPosition.x, 0.5f, targetPosition.y);
			while (Vector3.Distance(transform.position, targetWorldPosition) > 0.1f)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetWorldPosition, moveSpeed * Time.deltaTime);
				yield return null;
			}
			transform.position = targetWorldPosition;
			gridPosition = targetPosition;
		}

		isMoving = false;
	}
}