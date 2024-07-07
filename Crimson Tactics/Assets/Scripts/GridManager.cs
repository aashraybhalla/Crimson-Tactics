using UnityEngine;

public class GridManager : MonoBehaviour
{
	public GameObject tilePrefab;
	public int gridSize = 10;
	private GameObject[,] grid;

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
				tile.AddComponent<TileInfo>().SetPosition(x, y);
				grid[x, y] = tile;
			}
		}
	}
}