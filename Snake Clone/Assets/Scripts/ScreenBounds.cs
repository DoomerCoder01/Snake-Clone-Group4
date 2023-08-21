using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class ScreenBounds : MonoBehaviour
{
    public Camera mainCam;
    BoxCollider2D boxColl;

    public UnityEvent<Collider2D> ExitTriggerFired;

    [SerializeField] private float teleportOffset = 0.2f;
    [SerializeField] private float cornerOffset = 1;

    private void Awake()
    {
        this.mainCam.transform.localScale = Vector3.one;
        boxColl = GetComponent<BoxCollider2D>();
        boxColl.isTrigger = true;
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        UpdateBoundSize();

    }

    public void UpdateBoundSize()
    {
        float ySize = mainCam.orthographicSize * 2;
        Vector2 boxColliderSize = new Vector2(ySize * mainCam.aspect, ySize);
        boxColl.size = boxColliderSize;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTriggerFired?.Invoke(collision);
    }

    public bool OutOfBounds(Vector3 worldPosition)
    {
        return
            Mathf.Abs(worldPosition.x) > Mathf.Abs(boxColl.bounds.min.x) ||
            Mathf.Abs(worldPosition.y) > Mathf.Abs(boxColl.bounds.min.y);
    }

    public Vector2 CalculateWrappedPos(Vector2 worldPosition)
    {
        bool xBoundResult = Mathf.Abs(worldPosition.x) > (Mathf.Abs(boxColl.bounds.min.x) - cornerOffset);
        bool yBoundResult = Mathf.Abs(worldPosition.y) > (Mathf.Abs(boxColl.bounds.min.y) - cornerOffset);

        Vector2 signWorldPos = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

        if (xBoundResult && yBoundResult)
        {
            return Vector2.Scale(worldPosition, Vector2.one * -1) + Vector2.Scale(new Vector2(teleportOffset, teleportOffset), signWorldPos);
        }
        else if (xBoundResult)
        {
            return new Vector2(worldPosition.x * -1, worldPosition.y) + new Vector2(teleportOffset * signWorldPos.x, teleportOffset);
        }
        else if (yBoundResult)
        {
            return new Vector2(worldPosition.x, worldPosition.y * -1) + new Vector2(teleportOffset, teleportOffset * signWorldPos.y);
        }
        else
        {
            return worldPosition;
        }
    }
}
