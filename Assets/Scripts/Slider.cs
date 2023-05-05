using UnityEngine;
using DG.Tweening;

public class Slider : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float duration;

    private void Start()
    {
        transform.position = startPosition;
        MoveObject();
    }

    private void MoveObject()
    {
        transform.DOMove(endPosition, duration)
            .SetEase(Ease.InOutSine)
            .OnComplete(MoveBack);
    }

    private void MoveBack()
    {
        transform.DOMove(startPosition, duration)
            .SetEase(Ease.InOutSine)
            .OnComplete(MoveObject);
    }
}