using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSetup : MonoBehaviour
{
    public AnimationCurve curve;
    public float minFog = 0.06f;
    public float maxFog = 0.1f;
    public float transitionLength = 1;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogDensity = minFog;
    }

    public void GoToMaxFog()
    {
        StartCoroutine(GoToMaxFogRoutine());
    }

    IEnumerator GoToMaxFogRoutine()
    {
        float timer = 0;
        while(timer < transitionLength)
        {
            RenderSettings.fogDensity = Mathf.Lerp(minFog, maxFog, curve.Evaluate(timer / transitionLength));
            timer += Time.deltaTime;
            yield return null;
        }

        RenderSettings.fogDensity = maxFog;
    }
}
