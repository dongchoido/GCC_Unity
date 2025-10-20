using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
public class DrawMatrix : MonoBehaviour
{
    [Header("Thong so ma tran")]
    public Vector2Int gridSize;
    public Vector2 cellSize;

    private Vector2 mousePos;
    private Camera cam;

    [SerializeField] GameObject cellObj;

    public bool[,] data;
    void Awake()
    {
        cam = Camera.main;
        data = new bool[gridSize.x, gridSize.y];
    }

    void OnDrawGizmos()
    {
        Vector3 offset = new Vector3(-(gridSize.x - 1) * cellSize.x / 2, (gridSize.y - 1) * cellSize.y / 2);
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Vector3 pos = offset + new Vector3(i * cellSize.x, -j * cellSize.y, 0);
                Gizmos.DrawWireCube(pos, cellSize);
            }
        }
    }
    public Vector3 ClickCell() // chuyển từ vị trí chuột sang vị trí cell
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Mathf.Abs(mousePos.x) > Mathf.Abs(gridSize.x * cellSize.x / 2) || Mathf.Abs(mousePos.y) > Mathf.Abs(gridSize.y * cellSize.y / 2))
        { Debug.Log("O khong hop le"); return new Vector3(0, 0, 0); }
        else
        {
            mousePos += new Vector2(gridSize.x * cellSize.x / 2, gridSize.y * cellSize.y / 2);
            int x = Mathf.CeilToInt(mousePos.x / cellSize.x);
            int y = Mathf.CeilToInt(mousePos.y / cellSize.y);
            Debug.Log($"{x}:{y}");
            return new Vector3(x, y, 0);
        }
    }

    public bool CheckCell() // kiểm tra xem ô đã bị chiếm chưa
    {
        Vector3 mouPos = ClickCell();
        if (mouPos == Vector3.zero) return false;
        if (data[(int)mouPos.x - 1, (int)mouPos.y - 1]) return false;
        else { data[(int)mouPos.x - 1, (int)mouPos.y - 1] = true; return true; }
    }

    public void SetItem(Vector3 pos, Transform item) // dịch chuyển item vào ô tại vị trí pos
    {
        item.position = new Vector2(pos.x * cellSize.x - cellSize.x / 2 - cellSize.x * gridSize.x / 2, pos.y * cellSize.y - cellSize.y / 2 - cellSize.y * gridSize.y / 2);
    }
    
    public void SetNewItem(Vector3 pos) // tạo item mới tại vị trí ô pos
    {
        Instantiate(cellObj, new Vector2(pos.x * cellSize.x - cellSize.x / 2 - cellSize.x * gridSize.x / 2, pos.y * cellSize.y - cellSize.y / 2 - cellSize.y * gridSize.y / 2), Quaternion.identity);
    }
}
