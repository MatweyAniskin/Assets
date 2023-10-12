using System.Linq;

public class CollapsingGenerator : Generator
{
    public override void SetTileCache()
    {
        CacheMatrix.Add(CalculateCahche(), curX, curY);
    }
    TileCache CalculateCahche() => GetRandomTileCache(GetRight(GetUp(TileCacheRepository.GetTiles())));
    TileCache[] GetRuledTiles(TileCache[] tileCaches, int ruledValue, int referenceX, int referenceY,
        TileDirection.DirectionType referenceType, TileDirection.DirectionType requestType)
    {
        if (ruledValue == 0)
            return tileCaches;
        return tileCaches.Where(i => i.Direction(requestType) == CacheMatrix.Get(referenceX, referenceY).Direction(referenceType)).ToArray();
    }
    TileCache[] GetRight(TileCache[] tileCaches) => GetRuledTiles(tileCaches, curX, curX - 1, curY, TileDirection.DirectionType.Right, TileDirection.DirectionType.Left);
    TileCache[] GetUp(TileCache[] tileCaches) => GetRuledTiles(tileCaches, curY, curX, curY - 1, TileDirection.DirectionType.Up, TileDirection.DirectionType.Down);
}
