using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public List<SpriteRenderer> mat;

    public float speedMin;
    public float speedMax;

    private void Update()
    {
        BackgroundTiling();
    }

    public void BackgroundTiling()
    {
        foreach(SpriteRenderer m in mat)
        {
            float randomValue = Random.Range(speedMin, speedMax);
            Vector2 offset = Vector2.right * Time.deltaTime * randomValue + m.material.mainTextureOffset;
            m.material.SetTextureOffset("_MainTex", offset);
        }
    }
}