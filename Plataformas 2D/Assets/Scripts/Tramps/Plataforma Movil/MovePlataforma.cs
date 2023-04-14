using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class MovePlataforma : MonoBehaviour
{
    public Transform objectToMove;
    public Transform startPostion, endPostion;
    public float lerpTime = 5;
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
        yield return new WaitForSeconds(2);
        StartCoroutine(MoveCorroutine());
    }
    public void Swap()
    {
        Transform temp = startPostion;
        startPostion = endPostion;
        endPostion = temp; ;
    }
}
