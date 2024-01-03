using Loader;
using Repository;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenWithIcomBar : LoadScreen
{
    [SerializeField] RectTransform mainFrame;
    [SerializeField] BarLoadIcon iconPrefab;
    [SerializeField] Vector2 offset;
    [SerializeField] List<string> triggerNames;
    List<BarLoadIcon> instantiateIcons = new List<BarLoadIcon>();
    int halfCountIndex;
    protected override void OnStart()
    {
        halfCountIndex = triggerNames.Count / 2;
        LoadQueue.OnStartLoadService += SetNewIcon;
    }
    protected override void OnDelete()
    {
        LoadQueue.OnStartLoadService -= SetNewIcon;
    } 
    int NextIndex => instantiateIcons.Count - halfCountIndex;

    void SetNewIcon(string trigger)
    {
        if (trigger == string.Empty || 
            !IconRepository.IsIconsLoaded ||
            triggerNames.IndexOf(trigger) == -1 || 
            instantiateIcons.Count == triggerNames.Count)
            return;
        BarLoadIcon temp = Instantiate(iconPrefab, mainFrame) as BarLoadIcon;
        temp.SetIconBar(IconRepository.RandomSprite, offset * NextIndex);
        instantiateIcons.Add(temp);
    }
    void ClearInstantiate()
    {
        for (int i = 0; i < instantiateIcons.Count; i++)
        {
            instantiateIcons[i].Destroy();
            instantiateIcons.RemoveAt(i);
        }
    }
    public override void StartLoad()
    {
        ClearInstantiate();
        base.StartLoad();
    }
}
