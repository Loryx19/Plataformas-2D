using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockEnemy : MonoBehaviour
{
    [Header("Objeto a mover"), SerializeField] GameObject ObjectToMove;
    [Header("Detecion del personaje")]
    [SerializeField] Transform RayTransform;
    [SerializeField] float RayLengh;
    [SerializeField] LayerMask PlayerMask;
    [Header("Velocidad de bajada")]
    [SerializeField] float Speed;

    [Header("Variables para cuando suba")]
    [SerializeField] float TimeToUp;
    [SerializeField] Transform StartPos, EndPos;
    float ElapseTime;
    bool baja = true;
     
    private void Update()
    {
        if(Physics2D.Raycast(RayTransform.position, Vector3.down, RayLengh, PlayerMask))
        {
            baja = true;
            if(baja)
            {
                ObjectToMove.GetComponent<Rigidbody2D>().
              AddForce(Vector3.down * Speed, ForceMode2D.Force);
            }
        }
    }

    public IEnumerator VuelveEnemigo()
    {
        baja = false;
        yield return new WaitForSeconds(TimeToUp);
        ElapseTime = 0;
        while(ElapseTime < TimeToUp)
        {
            ElapseTime += Time.deltaTime;
            yield return null;
            ObjectToMove.transform.position = Vector3.Lerp(
                StartPos.position, EndPos.position, ElapseTime / TimeToUp);
            if(StartPos.position== EndPos.position)
            {
                baja= false;
                StopCoroutine(VuelveEnemigo());
            }
        }
    }
}
