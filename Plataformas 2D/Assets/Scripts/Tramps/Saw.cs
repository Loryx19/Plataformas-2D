using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Saw: MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform startPostion, endPostion;
    [SerializeField] float lerpTime = 5;
    [SerializeField] float TimeToStay;
    private void Start()
    {
        StartCoroutine(MoveCorroutine());
    }
    public IEnumerator MoveCorroutine()
    {
        float elapsedTime = 0;
        while (elapsedTime < lerpTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
            objectToMove.position = Vector3.Lerp(startPostion.position, endPostion.position, elapsedTime / lerpTime);
        }
        Swap();
        yield return new WaitForSeconds(TimeToStay);
        StartCoroutine(MoveCorroutine());
    }
    public void Swap()
    {
        Transform temp = startPostion;
        startPostion = endPostion;
        endPostion = temp; ;
    }
}
