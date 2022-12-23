using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //�������� �Ծ ���� ����
    //������Ƽ
    public int Score { get; private set; }

    //�÷��̾�
    //��Ʈ����Ʈ
    [SerializeField] private Transform cube;

    //������ ����Ʈ
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
                Debug.Log($"������ ȹ��   -���� : { Score}");
                LoadEffect(curItem.position);

                curItem.position = GetGeneractePosition();
            }
        }
    }

    private Vector3 GetGeneractePosition()
    {
        Vector3 curPos = Vector3.zero;

        while (true)
        {
            float width = 19;
            float randomX = Random.Range(-width / 2, width / 2);

            float heigh = 15;
            float randomZ = Random.Range(-heigh / 2, heigh / 2);

            curPos = new Vector3(randomX, 0, randomZ);

            if (Vector3.Distance(curPos, cube.position) > 2)
                break;
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
