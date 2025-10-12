using UnityEngine;

public class GameObj : MonoBehaviour
{
    // Awake --> Start --> OnEnable --> 
    void Awake()
    {
        Debug.Log("AW");
    }
    void Start()
    {
        Debug.Log("ST");
    }
    void OnEnable()
    {
        Debug.Log("oE");
    }
    void OnDisable()
    {
        Debug.Log("OD");
    }
    bool x1 = true, x2 = true, x3 = true;
    void Update()
    {
        if (x1)
        { Debug.Log("U"); x1 = false; }
    }
    void FixedUpdate()
    {
        if (x2)
        {
            x2 = false;
            Debug.Log("FU");
        }
    }
    void LateUpdate()
    {
        if(x3)
        {
            x3 = false;
            Debug.Log("LU");
        }
    }
}
