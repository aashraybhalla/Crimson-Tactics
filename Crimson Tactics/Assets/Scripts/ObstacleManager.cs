using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
	public GameObject obstaclePrefab; 
	public ObstacleData obstacleData; 

	void Start()
	{
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
					Instantiate(obstaclePrefab, position, Quaternion.identity);
				}
			}
		}
	}
}