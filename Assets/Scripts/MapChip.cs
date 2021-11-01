using System;
using UnityEngine;

public class MapChip : MonoBehaviour
{
    public Action onOpen;
    public Action onClose;

    public enum Status
    {
        None,
        Open,
        Closed
    }

    [SerializeField] SpriteRenderer _spriteRenderer;

    Vector2Int _nodeId;
    float _cost;
    float _hcost;
    int _nodeType;
    Status _currentStatus;
    MapChip _parentNode;

    public Vector2Int NodeId => _nodeId;
    public int NodeType => _nodeType;
    public float Cost { get => _cost; set => _cost = value; }
    public float HCost => _hcost;
    public float Score => _cost + _hcost;
    public Status CurrentStatus => _currentStatus;
    public MapChip ParentNode { get => _parentNode; set => _parentNode = value; }
    public Vector2 WorldPosition => transform.position;
    public Vector2 LocalPosition => transform.localPosition;

    public void Init(int x, int y, int nodeType)
    {
        _nodeId = new Vector2Int(x, y);
        _nodeType = nodeType;
        _currentStatus = Status.None;
        _parentNode = null;
    }

    public void UpdateNode(Vector2Int startNodeId, Vector2Int targetNodeId, bool isDiagonal)
    {
        int dx, dy;
        dx = Mathf.Abs(_nodeId.x - startNodeId.x);
        dy = Mathf.Abs(_nodeId.y - startNodeId.y);
        _cost = isDiagonal == true ? Mathf.Max(dx, dy) : dx + dy;

        dx = Mathf.Abs(targetNodeId.x - _nodeId.x);
        dy = Mathf.Abs(targetNodeId.y - _nodeId.y);
        _hcost = isDiagonal == true ? Mathf.Max(dx, dy) : dx + dy;
    }

    public void ResetNode()
    {
        _currentStatus = Status.None;
        _parentNode = null;
    }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    public void SetColor(float r, float g, float b, float a = 1)
    {
        _spriteRenderer.color = new Color(r, g, b, a);
    }

    public void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    public void Open()
    {
        _currentStatus = Status.Open;
    }

    public void Close()
    {
        _currentStatus = Status.Closed;
    }

    public void SetEnable(bool value)
    {
        _spriteRenderer.enabled = value;
    }

    public void SetOrderInLayer(int layer)
    {
        _spriteRenderer.sortingOrder = layer;
    }
}
