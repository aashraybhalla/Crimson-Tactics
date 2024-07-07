using UnityEngine;
using UnityEngine.UI;

public class TileHover : MonoBehaviour
{
	public Text tileInfoText;
	private TileInfo previousTile;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit))
		{
			TileInfo tileInfo = hit.transform.GetComponent<TileInfo>();
			if (tileInfo != null)
			{
				if (previousTile != tileInfo)
				{
					if (previousTile != null)
					{
						previousTile.ResetHighlight();
					}
					tileInfo.Highlight();
					previousTile = tileInfo;
				}
				tileInfoText.text = $"Tile Position: ({tileInfo.x}, {tileInfo.y})";
			}
		}
		else
		{
			if (previousTile != null)
			{
				previousTile.ResetHighlight();
				previousTile = null;
				tileInfoText.text = "";
			}
		}
	}
}