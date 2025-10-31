using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    private Coroutine popupCoroutine;
    public AnimationCurve showCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    public AnimationCurve hideCurve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    protected virtual void Popup(float animationDuration,bool isShowing)
    {
        if (popupCoroutine != null)
            StopCoroutine(popupCoroutine);
        popupCoroutine = StartCoroutine(PopupCoroutine(animationDuration,isShowing));
    }

    protected virtual IEnumerator PopupCoroutine(float animationDuration,bool isShowing)
    {
        AnimationCurve scaleCurve = (isShowing) ? showCurve : hideCurve;
        transform.localScale = Vector3.zero;
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            float t = elapsed / animationDuration;
            float scaleValue = scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scaleValue;
            yield return null;
        }
        popupCoroutine = null;
        transform.localScale = Vector3.one;
        gameObject.SetActive(isShowing);    
    }
}
