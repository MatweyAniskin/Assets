using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] Gradient spriteColor;
    [SerializeField] bool randomXFlip = true;
    Vector3 startPos;
    Vector3 endPos;
    float animationSpeed;
    public void SetCloud(Vector3 startPos, Vector3 endPos, float animationSpeed, Sprite sprite)
    {
        this.startPos = startPos;
        this.endPos = endPos;
        this.animationSpeed = animationSpeed;
        renderer.sprite = sprite;
        if (randomXFlip)
            renderer.flipX = Random.Range(0, 2) == 1;
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        float index = 0;
        while (index < 1)
        {
            index += Time.deltaTime * animationSpeed;
            transform.localPosition = Vector3.Lerp(startPos, endPos, index);
            renderer.color = spriteColor.Evaluate(index);
            yield return null;
        }
        Destroy(gameObject);
    }
}
