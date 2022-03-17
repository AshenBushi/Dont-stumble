using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MazeMovingController : MonoBehaviour
{
    [SerializeField] private float _mazeStartPoint = 8f;
    [SerializeField] private float _mazeEndPoint = -1f;
    [SerializeField] private float _durationMovingMaze = 10f;

    private MazeSpawnerCells _mazeSpawner;
    private Tween _tween;

    public static UnityEvent MazeCompleteEvent = new UnityEvent();
    public static UnityEvent MazeDestroyEvent = new UnityEvent();

    private void Awake()
    {
        _mazeSpawner = GetComponentInChildren<MazeSpawnerCells>();
        ScoreCounter.OnMazeActivationEvent.AddListener(Spawn);
    }

    public void Spawn()
    {
        MazeDestroyEvent.AddListener(Clear);

        _mazeSpawner.SpawnCells();

        transform.position = new Vector3(transform.position.x, _mazeStartPoint, transform.position.z);
        _tween = transform.DOMoveY(_mazeEndPoint, _durationMovingMaze).SetLink(gameObject).SetEase(Ease.Linear);

        _tween.OnComplete(() =>
        {
            Clear();
            MazeCompleteEvent?.Invoke();
        });
    }

    private void Clear()
    {
        _tween.OnKill(() =>
        {
            MazeDestroyEvent.RemoveListener(Clear);
            _mazeSpawner.Clear();
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        });
        
        _tween.Kill();
    }
}
