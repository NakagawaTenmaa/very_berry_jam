using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : SingletonMonoBehaviour<MapManager>
{
    List<Map> _mapList;

    public void AddMap(Map map)
    {
        if (_mapList == null)
        {
            _mapList = new List<Map>();
        }
        _mapList.Add(map);
    }

    public bool SearchRoute(int mapId, Vector2Int startNodeId, Vector2Int targetNodeId, List<Vector2Int> routeList)
    {
        if (IsOutOfRangeMapId(mapId) == false)
        {
            return false;
        }
        return _mapList[mapId].SearchRoute(startNodeId, targetNodeId, routeList);
    }

    public bool SearchRouteRandom(int mapId, Vector2Int startNodeId, List<Vector2Int> routeList)
    {
        if (IsOutOfRangeMapId(mapId) == false)
        {
            return false;
        }

        Vector2Int nodeId = Vector2Int.zero;
        int debugCount = 0;
        while (true)
        {
            int x = Random.Range(0, _mapList[mapId].MapWidth);
            int y = Random.Range(0, _mapList[mapId].MapHeight);
            nodeId = new Vector2Int(y, x);

            if (System.Convert.ToInt32(_mapList[mapId].MapData[y][x]) == 0
            &&  startNodeId != nodeId)
            {
                break;
            }

            debugCount++;
            if (debugCount >= 1000)
            {
                break;
            }
        }

        return _mapList[mapId].SearchRoute(startNodeId, nodeId, routeList);
    }

    public MapChip GetNode(int mapId, Vector2Int nodeId)
    {
        if (IsOutOfRangeMapId(mapId) == false)
        {
            return null;
        }

        return _mapList[mapId].GetNode(nodeId);
    }

    bool IsOutOfRangeMapId(int id)
    {
        if (id < 0 || id >= _mapList.Count)
        {
            Debug.LogError($"範囲外のマップIDです。mapId={id}");
            return false;
        }
        return true;
    }
}
