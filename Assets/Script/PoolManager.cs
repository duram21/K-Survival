using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PoolManager : MonoBehaviour
{
    // .. prefabs 보관할 변수
    public GameObject[] prefabs;

    // .. 풀 담당을 하는 리스트들
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for(int i = 0 ; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null;

        // ... 선택한 풀의 놀고 있는 GameObject 접근

            // ... 발견하면 select 변수에 할당
        foreach (GameObject item in pools[index])
        {
            if(!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if(!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        // ... 

        return select;
    }
}
