using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
public class DrawMatrix : MonoBehaviour
{
    [Header("Thong so ma tran")]
    [SerializeField] Vector2Int gridSize;
    [SerializeField] Vector2 cellSize;

    private Vector3 mousePos;
    private Camera camera;

    void Awake()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ClickCell();
        }
    }
    void OnDrawGizmos()
    {
        for (float i = -(float)gridSize.x / 2 + 0.5f; i <= (float)gridSize.x / 2 - 0.5f; i++)
        {
            for (float j = -(float)gridSize.y / 2 + 0.5f; j <= (float)gridSize.y / 2 - 0.5f; j++)
            {
                Vector3 pos = new Vector3(i * cellSize.x, j * cellSize.y, 0);
                Gizmos.DrawWireCube(pos, cellSize);
            }
        }
    }
    void ClickCell()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        if (Mathf.Abs(mousePos.x )> Mathf.Abs(gridSize.x * cellSize.x / 2 )|| Mathf.Abs(mousePos.y) > Mathf.Abs(gridSize.y * cellSize.y / 2))
            Debug.Log("O khong hop le");
        else
        {
            mousePos += new Vector3(gridSize.x * cellSize.x / 2, gridSize.y * cellSize.y / 2);
            int x = Mathf.CeilToInt(mousePos.x / cellSize.x);
            int y = Mathf.CeilToInt(mousePos.y / cellSize.y);
            Debug.Log($"x:  {x}  y:  {y}");
        }
    }
}
