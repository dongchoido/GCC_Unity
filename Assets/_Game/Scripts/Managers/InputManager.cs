using UnityEngine;
using UnityEngine.Analytics;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    [SerializeField] DrawMatrix drawMatrix;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Tray tray;
    IDragable dragable;
    Camera cam;
    RaycastHit2D item;
    Vector2  prevPos;
    void Awake()
    {
        cam = Camera.main;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    void Update()
    {
        playerMovement.Move(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            item = Physics2D.Raycast(MousePos(), Vector2.zero);
            if(drawMatrix.CheckCell() && item.collider == null)
            {
                drawMatrix.SetNewItem(drawMatrix.ClickCell());
            }
            if (item.collider != null)
                dragable = item.transform.GetComponent<IDragable>();
            if (item.transform != null)
                prevPos = item.transform.position;
            drawMatrix.ClickCell();
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
        if (Input.GetKeyDown(KeyCode.P))
            playerMovement.Attack();
    }

    public Vector2 MousePos() => cam.ScreenToWorldPoint(Input.mousePosition);

    public bool CheckDropItem() // Nếu ô chưa chứa gì thì cho vào, ko thì quay lại vị trí cũ
    {
        if (drawMatrix.CheckCell() && dragable != null)
        {
            drawMatrix.SetItem(drawMatrix.ClickCell(), item.transform);
            return true;
        }
        else item.transform.position = prevPos;
        return false;
    }

    public Transform PlayerTransform() => playerMovement.transform;

}
