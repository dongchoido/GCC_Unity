using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Scale Settings")]
    public Vector3 minScale = Vector3.one;
    public Vector3 maxScale = new Vector3(2f, 2f, 2f);
    public float scaleDuration = 1f;

    [Header("Color Settings")]
    public float colorDuration = 2f;
    public Color colorA = Color.red;
    public Color colorB = Color.blue;

    [Header("Move Settings")]
    public float moveHeight = 1f;
    public float moveDuration = 1.5f;

    private Renderer rend;
    private Vector3 startPos;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        startPos = transform.position;
    }
    void OnEnable()
    {
        StartCoroutine(ScaleLoop());
        StartCoroutine(ColorLoop());
        StartCoroutine(MoveLoop());
    }

    IEnumerator ScaleLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ScaleEnemy(minScale, maxScale, scaleDuration));
            yield return StartCoroutine(ScaleEnemy(maxScale, minScale, scaleDuration));
        }
    }

    IEnumerator ScaleEnemy(Vector3 from, Vector3 to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, time / duration);
            transform.localScale = Vector3.Lerp(from, to, t);
            yield return null;
        }
    }

    IEnumerator ColorLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ChangeColor(colorA, colorB, colorDuration));
            yield return StartCoroutine(ChangeColor(colorB, colorA, colorDuration));
        }
    }

    IEnumerator ChangeColor(Color from, Color to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, time / duration);
            rend.material.color = Color.Lerp(from, to, t);
            yield return null;
        }
    }

    IEnumerator MoveLoop()
    {
        Vector3 upPos = startPos + Vector3.up * moveHeight;
        Vector3 downPos = startPos - Vector3.up * moveHeight;

        while (true)
        {
            yield return StartCoroutine(MoveEnemy(downPos, upPos, moveDuration));
            yield return StartCoroutine(MoveEnemy(upPos, downPos, moveDuration));
        }
    }

    IEnumerator MoveEnemy(Vector3 from, Vector3 to, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
            float t = Mathf.SmoothStep(0f, 1f, time / duration);
            Vector3 newPos = Vector3.Lerp(from, to, t);
            rb.MovePosition(newPos);
        }
    }

    void OnDestroy()
    {
        StopAllCoroutines();
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }
}
