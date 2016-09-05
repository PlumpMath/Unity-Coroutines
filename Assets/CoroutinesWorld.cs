using UnityEngine;
using System.Collections;

public class CoroutinesWorld : MonoBehaviour
{
    void Start()
    {
        print("Start Method");
        //RunInSequence(); //this method does not work at the moment use AnotherWaySequence() instead
        AnotherWaySequence();
        //RunInParallel();
    }

    IEnumerator CountTo100()
    {
        int count = 0;
        while (count <= 100)
        {
            print(count);
            count++;
            yield return null;
        }
    }

    IEnumerator PrintAlphabets()
    {
        int count = 0;
        while (count < 26)
        {
            print(System.Convert.ToChar(count + 65));
            count++;
            yield return null;
        }
    }
    public IEnumerator RunInSequence()
    {
        print("running coroutines in sequence");
        yield return StartCoroutine(PrintAlphabets());
        yield return StartCoroutine(CountTo100());
    }

    public void RunInParallel()
    {
        StartCoroutine(PrintAlphabets());
        StartCoroutine(CountTo100());
    }

    public static IEnumerator Sequence(params IEnumerator[] sequence)
    {
        for (int i = 0; i < sequence.Length; ++i)
        {
            while (sequence[i].MoveNext())
                yield return sequence[i].Current;
        }
    }

    public void AnotherWaySequence()
    {
        StartCoroutine(Sequence(PrintAlphabets(), CountTo100()));
    }
}
