using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	public GameObject obstaclePrefab; 
	public ObstacleData obstacleData;
	private GameObject[,] grid; // Assuming you have a grid of GameObjects

	void Start()
	{
		grid = new GameObject[obstacleData.obstacleData.columns, obstacleData.obstacleData.rows];
		GenerateObstacles();
	}

	void GenerateObstacles()
	{
		int rows = obstacleData.obstacleData.rows;
		int columns = obstacleData.obstacleData.columns;

		for (int x = 0; x < columns; x++)
		{
			for (int y = 0; y < rows; y++)
			{
				if (obstacleData.obstacleData[x, y])
				{
					Vector3 position = new Vector3(x, 0.5f, y); 
					GameObject obstacle = Instantiate(obstaclePrefab, position, Quaternion.identity);
					grid[x, y] = obstacle; // Assign the obstacle to the grid

					// Check if the obstacle has the TileInfo component
					TileInfo tile = obstacle.GetComponent<TileInfo>();
					if (tile != null)
					{
						tile.tileHasObstacle = true;
						tile.SetPosition(x, y); // Update position in TileInfo
					}
				}
			}
		}
	}
}