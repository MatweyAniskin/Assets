using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : StepListener
{
    [SerializeField] FadeProfile profile;
    [SerializeField] List<SpriteRenderer> renderers;
    Transform camera;
    public override void OnStart()
    {
        camera = Camera.main.transform;
        
        base.OnStart();
    }
    public override void OnActiveObject()
    {
        
        base.OnActiveObject();
    }
    public override void StepAction() => RecalculateAlphaChanel();
    void RecalculateAlphaChanel() => renderers.ForEach(i => i.color = profile.GetFadeColor(Vector3.Distance(transform.position, camera.position)));
}
