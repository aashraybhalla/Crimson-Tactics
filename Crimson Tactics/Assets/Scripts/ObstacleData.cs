using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{
	public BoolArray2D obstacleData = new BoolArray2D(10, 10); // Assigment 1: 10x10 grid
}

[System.Serializable]
public class BoolArray2D
{
	public int rows;
	public int columns;
	public bool[] array;

	public BoolArray2D(int rows, int columns)
	{
		this.rows = rows;
		this.columns = columns;
		array = new bool[rows * columns];
	}

	public bool this[int x, int y]
	{
		get { return array[x + y * columns]; }
		set { array[x + y * columns] = value; }
	}
}