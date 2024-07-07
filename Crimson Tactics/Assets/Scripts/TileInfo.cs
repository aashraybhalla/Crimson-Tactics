using UnityEngine;

public class TileInfo : MonoBehaviour
{
	public int x;
	public int y;
	public bool tileHasObstacle = false; // Added obstacle flag
	private Renderer tileRenderer;
	private Color originalColor;

	void Start()
	{
		tileRenderer = GetComponent<Renderer>();
		originalColor = tileRenderer.material.color;
	}

	public void SetPosition(int x, int y)
	{
		this.x = x;
		this.y = y;
		transform.localPosition = new Vector3(x, 0, y); // Update position in the world
	}

	public void Highlight()
	{
		tileRenderer.material.color = Color.yellow;
	}

	public void ResetHighlight()
	{
		tileRenderer.material.color = originalColor;
	}
}