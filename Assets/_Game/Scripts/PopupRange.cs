using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class PopupRange : MonoBehaviour
{
    private bool poped = false;
    [SerializeField] GameObject popup;
    private WaitForSeconds wait;
    void Start()
    {
        popup.SetActive(false);
        wait = new WaitForSeconds(2f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !poped)
        {
            poped = true;
            StartCoroutine(PopupTiming());
        }
    }
    IEnumerator PopupTiming()
{
    popup.SetActive(true);
        yield return wait;
    popup.SetActive(false);
}

}

