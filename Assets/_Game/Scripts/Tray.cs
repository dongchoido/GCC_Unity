using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tray : MonoBehaviour
{
    public List<GameObject> items;
    [SerializeField] Vector2 cellSize;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        PutItemOnTray();
        ReorderItemsOnTray();
    }

    void DrawTray()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Vector3 pos = transform.position + new Vector3(0, i * cellSize.y, 0);
            Gizmos.DrawWireCube(pos, cellSize);
        }
    }
    void OnDrawGizmos()
    {
        DrawTray();
    }

    void ReorderItemsOnTray()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = transform.position + new Vector3(0, i * cellSize.y, 0);
        }
    }
    void PutItemOnTray()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Instantiate(items[i], transform.position + new Vector3(0, i * cellSize.y, 0), Quaternion.identity, transform);
        }
    }

    void TakeItem(int i)
    {
        items.RemoveAt(i);
        ReorderItemsOnTray();
    }

}
