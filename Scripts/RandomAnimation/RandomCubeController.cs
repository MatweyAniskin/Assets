using UnityEngine;

public class RandomCubeController : MonoBehaviour
{
    [SerializeField] RandomCube[] randomCubes;
    static int maxValue = 0;
    static int minValue = 0;
    public delegate RandomCubeValue RandomValueDelegate();    
    public static RandomValueDelegate GetRandomValues;  

    public static int CubeCount { get; protected set; }
    private void Start()
    {
        foreach (var i in randomCubes)
        {
            maxValue += i.Max;
            minValue += i.Min;
        }
        CubeCount = randomCubes.Length;
        maxValue -= minValue;
        GetRandomValues += RandomValues;
    }
    private void OnDestroy()
    {
        GetRandomValues -= RandomValues;
    }    
    public RandomCubeValue RandomValues()
    {
        RandomCubeValue cubeValue = new RandomCubeValue();
        foreach (var i in randomCubes)
        {
            cubeValue.Add(i.Random);
        }                
        return cubeValue;
    }
    public static float Random01(RandomCubeValue randomCubeValue) => Random01(randomCubeValue.GeneralValue);
    public static float Random01(float value) => (value - minValue) / maxValue;
}
