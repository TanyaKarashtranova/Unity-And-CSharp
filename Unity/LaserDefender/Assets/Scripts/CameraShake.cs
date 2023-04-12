using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float timeForShake = 0.5f;
    [SerializeField] private float magnitude = 0.2f;
    private Vector2 minPoint = new Vector2(-1, -1);
    private Vector2 maxPoint = new Vector2(1, 1);
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float time = timeForShake;
        while (time > 0)
        {
            time -= Time.deltaTime;
            float x = originalPosition.x + Random.Range(minPoint.x, maxPoint.x) * magnitude;
            float y = originalPosition.y + Random.Range(minPoint.y, maxPoint.y) * magnitude;
            transform.position = new Vector3(x, y, originalPosition.z);
            yield return new WaitForEndOfFrame();
        }
        transform.position = originalPosition;
    }
}
