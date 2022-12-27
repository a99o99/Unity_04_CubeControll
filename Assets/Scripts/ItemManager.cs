using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //아이템을 먹어서 생긴 점수
    //프로퍼티
    public int Score { get; private set; }

    //플레이어
    //어트리뷰트
    [SerializeField] private Transform cube;

    //아이템 리스트
    List<Transform> itemList = new List<Transform>();

    void Start()
    {
        InitItemList(15);
    }

    private void InitItemList(int itemCount)
    {
        var itemRes = Resources.Load<Transform>("Item");

        for (int i = 0; i < itemCount; i++)
        {
            var itemTransform = Instantiate(itemRes);

            itemTransform.position = GetGeneractePosition();
            itemList.Add(itemTransform);
        }
    }

    void Update()
    {
        for(int i = 0; i<itemList.Count; i++)
        {
            var curItem = itemList[i];
            if(Vector3.Distance(curItem.position, cube.position) < 0.7f)
            {
                Score += 10;
                Debug.Log($"아이템 획득   -점수 : { Score}");
                //LoadEffect(curItem.position);

                curItem.position = GetGeneractePosition();
            }
        }
    }

    private Vector3 GetGeneractePosition()
    {
        Vector3 curPos = Vector3.zero;

        //while (true)
        //{
        //    float width = 19;
        //    float randomX = Random.Range(-width / 2, width / 2);

        //    float heigh = 15;
        //    float randomZ = Random.Range(-heigh / 2, heigh / 2);

        //    curPos = new Vector3(randomX, 0, randomZ);

        //    if (Vector3.Distance(curPos, cube.position) > 2)
        //        break;
        //}


        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            int randX = Random.Range(0, 2);

            float posX = randX == 0 ? 9.5f : -9.5f;
            float posZ = Random.Range(-7.5f, 7.5f);
            curPos = new Vector3(posX, 0, posZ);
        }
        else
        {
            int randZ = Random.Range(0, 2);

            float posZ = randZ == 0 ? 7.5f : -7.5f;
            float posX = Random.Range(-9.5f, 9.5f);
            curPos = new Vector3(posX, 0, posZ);
        }

        return curPos;

    }

    public void LoadEffect(Vector3 GetCoinPos)
    {
        var GetCoinEfe = Resources.Load<Transform>("EftGetCoin");
        GetCoinEfe.position = GetCoinPos;
        Instantiate(GetCoinEfe);
    }

}
