using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform[] points;
    [SerializeField] AnimationCurve ease;
    [SerializeField] float animationDuration;

    int from = 0;
    int to = 1;
    float elapsedTime;
    bool canMove = false;  // Nueva variable para controlar si la plataforma puede moverse

    void Start()
    {
        // Iniciamos la coroutine, pero la plataforma no se moverá hasta que se active el trigger
        StartCoroutine(AnimationLinearInterpolation());
    }

    IEnumerator AnimationLinearInterpolation()
    {
        while (true)
        {
            if (canMove)
            {
                elapsedTime = 0;

                while (elapsedTime < animationDuration)
                {
                    elapsedTime += Time.deltaTime;

                    objectToMove.position = Vector3.LerpUnclamped(
                        points[from].position,
                        points[to].position,
                        ease.Evaluate(elapsedTime / animationDuration)
                    );

                    yield return null;
                }

            }

            IndexCount();
            

            yield return null;
        }
    }

    void IndexCount()
    {
        from = to;
        to = (to + 1) % points.Length;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("puedo entrar");
            canMove = true;
        }
    }
    
}

