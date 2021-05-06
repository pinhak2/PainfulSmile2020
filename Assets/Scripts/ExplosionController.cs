using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private SpriteRenderer rend;
    public GameObject sprite;

    private void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        startFading();
    }

    private IEnumerator FadeOut()
    {
        for (float f = 1; f >= -0.3f; f -= 0.3f)
        {
            ChangeSpriteSize(f);
            ChangeSpriteAlpha(f);

            yield return new WaitForSeconds(0.05f);
        }
        Destroy(this.gameObject);
    }

    private void ChangeSpriteAlpha(float f)
    {
        Color c = rend.material.color;
        c.a = f;
        rend.material.color = c;
    }

    private void ChangeSpriteSize(float f)
    {
        Vector3 spriteTransform = sprite.transform.localScale;
        spriteTransform = new Vector3(spriteTransform.x - f, spriteTransform.y - f, 0);
        sprite.transform.localScale = spriteTransform;
    }

    public void startFading()
    {
        StartCoroutine("FadeOut");
    }
}