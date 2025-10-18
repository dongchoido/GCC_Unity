using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] int[,] data;
    private DrawMatrix drawMatrix;
    void Awake()
    {
        data = new int[drawMatrix.gridSize.x, drawMatrix.gridSize.y];
    }
    
}
