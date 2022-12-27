using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public int HP { get; private set; }

    [SerializeField] private Transform player;

    List<Transform> monsterList = new List<Transform>();

    GameObject monsterRoot;

    void Start()
    {
        monsterRoot = new GameObject("@monsterRoot");

        HP = 100;
        InitMonsterList(15);
    }

    private void InitMonsterList(int monsterCount)
    {
        var monsterRes = Resources.Load<Monster>("Monster");

        for (int i = 0; i < monsterCount; i++)
        {
            var monster = Instantiate(monsterRes);

            monster.transform.position = GetGeneractePosition();
            monsterList.Add(monster.transform);
            monster.SetTarget(player);
        }
    }

    void Update()
    {
        MonsterAttack();
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

    private void MonsterAttack()
    {
        for(int i = 0; i < monsterList.Count; i++)
        {
            var curMon = monsterList[i];
            if(Vector3.Distance(curMon.position,player.position) < 1.5f)
            {
                HP -= 10;
                Debug.Log($"ÇöÀç HP = {HP}");

                curMon.position = GetGeneractePosition();
            }
        }
    }

    public void LoadEffect(Vector3 GetCoinPos)
    {
        var GetCoinEfe = Resources.Load<Transform>("EftGetCoin");
        GetCoinEfe.position = GetCoinPos;
        Instantiate(GetCoinEfe);
    }
}
