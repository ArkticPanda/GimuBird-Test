using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundChanger : MonoBehaviour
{
    // Duration of the fade in seconds
    public float fadeDuration = 30.0f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No SpriteRenderer component found on this GameObject.");
            return;
        }

        // Start the coroutine to manage the fading process
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        // Start fading out
        yield return StartCoroutine(FadeOut());

        // Start fading in
        yield return StartCoroutine(FadeIn());

        // Repeat the process
        StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            color.a = alpha;
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 0f;
        spriteRenderer.color = color;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            color.a = alpha;
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 1f;
        spriteRenderer.color = color;
    }
}
