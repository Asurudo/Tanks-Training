using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    stage1: 1 - teki1; 1 - teki2
    stage2: 2 - teki1; 1 - teki2
    stage3: 2 - teki1; 2 - teki2: speed up
    stage4: 3 - teki1; 2 - teki2: speed up
    stage5: 3 - teki1: speed up; 3 - teki2: speed up up
 */


public class StageControl : MonoBehaviour
{
    private int stage;
    public int liveteki;
    //计时器
    private float lastTime;
    private float curTime;
    public float gapTime;

    //敌人
    public GameObject TankTeki1;
    public GameObject TankTeki2;

    //实例化后的敌人
    private List<GameObject> Teki1 = new List<GameObject>();
    private List<GameObject> Teki2 = new List<GameObject>();

    //获取玩家
    private GameObject playerObject;

    //冰冻
    private int freezenow;
    private float freezestartTime;
    public float freezeTime;
    public float freezedis;
    List<int> Teki1index = new List<int>();
    List<int> Teki2index = new List<int>();

    //无敌
    private int mutekinow;
    private float mutekistartTime;
    private float mutekiHP;
    public float mutekiTime;

    void Start()
    {
        stage = liveteki = freezenow = 0;
        curTime = Time.time;
        lastTime = curTime - gapTime + 1;
        playerObject = GameObject.Find("Tank1");
        mutekiHP = playerObject.GetComponent<TankHealth>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        mutekiHP = System.Math.Min(mutekiHP, playerObject.GetComponent<TankHealth>().HP);
        if (freezenow == 1 && Time.time - freezestartTime > freezeTime)
            unfreeze();
        if (mutekinow == 1 && Time.time - mutekistartTime > mutekiTime)
            unmuteki();
        curTime = Time.time;
        if (curTime - lastTime < gapTime && liveteki != 0)
            return;
        lastTime = Time.time;
        stage ++;

        if (stage == 1)
        {
            liveteki += 2;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki2.Add(GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject);
        }
        else if (stage == 2)
        {
            liveteki += 3;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki2.Add(GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject);
        }
        else if (stage == 3)
        {
            liveteki += 4;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 5;
            teki21.GetComponent<NavMeshAgent>().acceleration += 5;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
            Teki2.Add(teki21);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 5;
            teki22.GetComponent<NavMeshAgent>().acceleration += 5;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
            Teki2.Add(teki22);
        }
        else if (stage == 4)
        {
            liveteki += 5;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 5;
            teki21.GetComponent<NavMeshAgent>().acceleration += 5;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
            Teki2.Add(teki21);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 5;
            teki22.GetComponent<NavMeshAgent>().acceleration += 5;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.2f;
            Teki2.Add(teki22);
        }
        else if (stage == 5)
        {
            liveteki += 6;

            Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            Teki1.Add(GameObject.Instantiate(TankTeki1, randomPosition, playerObject.transform.rotation) as GameObject);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki21 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki21.GetComponent<NavMeshAgent>().speed += 10;
            teki21.GetComponent<NavMeshAgent>().acceleration += 10;
            teki21.GetComponent<TankAttack2>().attackgapTime -= 0.4f;
            Teki2.Add(teki21);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki22 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki22.GetComponent<NavMeshAgent>().speed += 10;
            teki22.GetComponent<NavMeshAgent>().acceleration += 10;
            teki22.GetComponent<TankAttack2>().attackgapTime -= 0.4f;
            Teki2.Add(teki22);

            randomPosition = new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
            GameObject teki23 = GameObject.Instantiate(TankTeki2, randomPosition, playerObject.transform.rotation) as GameObject;
            teki23.GetComponent<NavMeshAgent>().speed += 10;
            teki23.GetComponent<NavMeshAgent>().acceleration += 10;
            teki23.GetComponent<TankAttack2>().attackgapTime -= 0.4f;
            Teki2.Add(teki23);
        }
        else 
        {
            Debug.Log("Game Over!");
        }
    }

    void freezefunc()
    {
        if (freezenow == 1)
            unfreeze();
        freezestartTime = Time.time;
        freezenow = 1;
        //遍历所有teki1
        for (int i = 0; i < Teki1.Count; i++)
        {
            if (Teki1[i] == null)
                continue;
            //找到符合距离范围的
            if (Vector3.Distance(Teki1[i].transform.position, playerObject.transform.position) <= freezedis)
            {
                //存下标
                Teki1index.Add(i);
                Teki1[i].GetComponent<NavMeshAgent>().enabled = false;
                Teki1[i].GetComponent<TankMovementTeki1>().enabled = false;
            }
        }
        
        //遍历所有teki2
        for (int i = 0; i < Teki2.Count; i++)
        {
            if (Teki2[i] == null)
                continue;
            //找到符合距离范围的
            if (Vector3.Distance(Teki2[i].transform.position, playerObject.transform.position) <= freezedis)
            {
                //存下标
                Teki2index.Add(i);
                Teki2[i].GetComponent<NavMeshAgent>().enabled = false;
                Teki2[i].GetComponent<TankAttack2>().enabled = false;
                Teki2[i].GetComponent<TankMovementTeki2>().enabled = false;
            }
        }
        
    }

    void mutekifunc()
    {
        mutekistartTime = Time.time;
        mutekinow = 1;
        playerObject.GetComponent<TankHealth>().HP = 100000;
    }

    void unmuteki()
    {
        mutekinow = 0;
        playerObject.GetComponent<TankHealth>().HP = mutekiHP;
    }

    void unfreeze()
    {
        freezenow = 0;
        for (int i = 0; i < Teki1index.Count; i++)
            if(Teki1[Teki1index[i]] != null)
            { 
                Teki1[Teki1index[i]].GetComponent<NavMeshAgent>().enabled = true;
                Teki1[Teki1index[i]].GetComponent<TankMovementTeki1>().enabled = true;
            }
        for (int i = 0; i < Teki2index.Count; i++)
        {
            if (Teki2[Teki2index[i]] == null)
                continue;
            Teki2[Teki2index[i]].GetComponent<NavMeshAgent>().enabled = true;
            Teki2[Teki2index[i]].GetComponent<TankAttack2>().enabled = true;
            Teki2[Teki2index[i]].GetComponent<TankMovementTeki2>().enabled = true;
        }
        Teki1index.Clear();
        Teki2index.Clear(); 
    }
}
