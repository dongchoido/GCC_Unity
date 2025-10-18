using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] DrawMatrix drawMatrix;
    [SerializeField] Tray tray;
    private bool isHolding = false;
    IDragable dragable;
    Camera cam;
    RaycastHit2D item;
    Vector2  prevPos;
    void Awake()
    {
        cam = Camera.main;
        if (instance == null)
            instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            item = Physics2D.Raycast(MousePos(), Vector2.zero);
            if (item.collider != null)
                dragable = item.transform.GetComponent<IDragable>();
            if(item.transform != null)
                prevPos = item.transform.position;
            drawMatrix.ClickCell();
            isHolding = true;
        }
        if (Input.GetMouseButton(0))
        {
            if (dragable != null)
            {
                dragable.OnDrag();
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(dragable!=null)
            {
                dragable.OnDrop();
                dragable = null;
            }
        }

    }

    public Vector2 MousePos() => cam.ScreenToWorldPoint(Input.mousePosition);

    public bool CheckDropItem()
    {
        if (drawMatrix.CheckCell() && dragable != null)
        {
            drawMatrix.SetItem(drawMatrix.ClickCell(), item.transform);
            return true;
        }
        else item.transform.position = prevPos;
        return false;
    }
}
