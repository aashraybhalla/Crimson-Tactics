using UnityEngine;

public class GridManager : MonoBehaviour
{
	public GameObject tilePrefab;
	public int gridSize = 10;
	private GameObject[,] grid;
	private float tileOffset = 1f;

	void Start()
	{
		GenerateGrid();
	}

	void GenerateGrid()
	{
		grid = new GameObject[gridSize, gridSize];

		for (int x = 0; x < gridSize; x++)
		{
			for (int y = 0; y < gridSize; y++)
			{
				GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
				tile.name = $"Tile_{x}_{y}";
				TileInfo tileInfo = tile.AddComponent<TileInfo>();
				tileInfo.SetPosition(x, y); // Ensure TileInfo sets the position correctly

				grid[x, y] = tile;
			}
		}
	}

	public Vector3 GetWorldPosition(Vector2Int gridPosition)
	{
		if (grid == null || gridPosition.x < 0 || gridPosition.y < 0 || gridPosition.x >= gridSize || gridPosition.y >= gridSize)
		{
			Debug.LogError($"Invalid grid position: {gridPosition}");
			return Vector3.zero; // Or some default position
		}

		GameObject tile = grid[gridPosition.x, gridPosition.y];
		if (tile != null)
		{
			return tile.transform.position;
		}

		Debug.LogError($"Tile at grid position {gridPosition} is null.");
		return Vector3.zero; // Or some default position
	}




	// Method to get grid coordinates from world position
	public Vector2Int WorldToGridPosition(Vector3 worldPosition)
	{
		int x = Mathf.FloorToInt(worldPosition.x / tileOffset);
		int y = Mathf.FloorToInt(worldPosition.z / tileOffset);

		return new Vector2Int(x, y);
	}
}