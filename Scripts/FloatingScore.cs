using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FloatingScore : MonoBehaviour
{
    public float DestroyTime = 2f;
    public TMP_Text floatingscore;


    void Start()
    {
        AnimateScore();
        Destroy(gameObject, DestroyTime);
    }

    void AnimateScore()
    {
        // Set the initial scale to zero (hidden)
        transform.localScale = Vector3.zero;

        // Animate the scale up to 1.5 (pop up) over 0.5 seconds, then shrink to 0.5 over the remaining time
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.04f)
            .setEaseOutBack() // For a popping effect
            .setOnComplete(() =>
            {
                LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 0.5f), DestroyTime - 0.5f)
                    .setEaseInQuad(); // Smooth shrinking effect
            });
    }

}
