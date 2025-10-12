using System.Collections.Generic;
using UnityEngine;

public class CSBasicsAndUnity : MonoBehaviour
{
    readonly string email = "Hello@gmail.com";
    private void Start()
    {
    }
    private void KeyWords()
    {
        var HP = 1.0f;
        Dictionary<int, string> dict = new Dictionary<int, string>();
        foreach (var key in dict)
        {
            Debug.Log(key);
        }
    }
}
