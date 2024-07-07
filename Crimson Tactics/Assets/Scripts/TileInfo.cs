using UnityEngine;

public class TileInfo : MonoBehaviour
{
	public int x;
	public int y;
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
	}

	public void Highlight()
	{
		tileRenderer.material.color = Color.yellow;
	}

	public void ResetHighlight()
	{
		tileRenderer.material.color = originalColor;
		StopAllCoroutines(); // Stop jiggling effect if any
		transform.localPosition = new Vector3(x, 0, y); // Reset position
	}

	
}