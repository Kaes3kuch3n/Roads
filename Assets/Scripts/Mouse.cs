using UnityEngine;

public class Mouse : MonoBehaviour {

    [SerializeField]
    private string buildKey = "Fire1";
    [SerializeField]
    private Sprite buildTile;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos = new Vector2(mouseWorldPos.x, mouseWorldPos.y);
        this.transform.position = mousePos;

        ProcessInput(mousePos);
    }

    private void ProcessInput(Vector2 mousePosition)
    {
        if (Input.GetButtonDown(buildKey))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0.0F);
            
            if (hit.transform != null)
            {
                World.Instance.ChangeTile(hit.transform.gameObject, buildTile);
            }
        }
    }
}
