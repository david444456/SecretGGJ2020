
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AnimationWinChest : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] GameObject Fade;
    [SerializeField] float velocityFade = 0.1f;

    [Header("Change IMAGE x2")]
    [SerializeField] Image imageChest;
    [SerializeField] Sprite spriteToChange;

    [Header("Change IMAGE normal")]
    [SerializeField] Image imageChestNormal;
    [SerializeField] Sprite spriteToChangeNormal;

    bool isRewarded = false;

    public void StartFadeAnimation(bool isX2Reward) {


        isRewarded = isX2Reward;
        StartCoroutine(FadeRoutine(1, velocityFade));
        GetComponent<RandomSound>().changeSoundRandom();
    }

    public void EndFadeAnimation() {

        StartCoroutine(FadeRoutine(0, velocityFade * 4));
    }


    IEnumerator FadeRoutine(float target, float time)
    {
        if (target == 0)
        {

            if (isRewarded)
            {
                imageChest.sprite = spriteToChange;
            }
            else imageChestNormal.sprite = spriteToChangeNormal;
        }

        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
            yield return null;
        }
    }
}
