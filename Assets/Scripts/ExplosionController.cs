using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    SpriteRenderer rend;
    public GameObject sprite;
    private void Awake()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        startFading();
    }


    IEnumerator FadeOut()
    {
        for(float f = 1; f >= -0.3f; f -= 0.3f)
        {
            Vector3 spriteTransform = sprite.transform.localScale;
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            spriteTransform = new Vector3(spriteTransform.x - 0.3f, spriteTransform.y - 0.3f, 0);
            sprite.transform.localScale = spriteTransform;
            yield return new WaitForSeconds(0.05f);
        }
       Destroy(this.gameObject);
    }

    public void startFading()
    {
        StartCoroutine("FadeOut");
    }
}
