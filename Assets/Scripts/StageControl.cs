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
    //宏定义
    const int ON = 1;
    const int OFF = 0;
    const int INF = 1000000;
    
    //现在的关卡数
    private int curStage;
    //活着的敌人数量
    public int liveTeki;
    //关卡计时器
    private float stageLastTime;
    private float stageCurTime;
    public float stageGapTime;

    //敌人
    public GameObject tankTeki1;
    public GameObject tankTeki2;

    //实例化后的敌人列表
    private List<GameObject> tankTeki_1_List = new List<GameObject>();
    private List<GameObject> tankTeki_2_List = new List<GameObject>();

    //玩家
    private GameObject playerObject;

    //冰冻
    private int freezeState;
    private float freezeStartTime;
    public float freezeLastingTime;
    public float freezeDistance;
    //被冰冻住的敌人下标列表
    List<int> tankTeki_1_FreezeIndexList = new List<int>();
    List<int> tankTeki_2_FreezeIndexList = new List<int>();

    //无敌
    private int mutekiState;
    private float mutekiStartTime;
    //无敌前的血量
    private float mutekiBeforeHP;
    public float mutekiLastingTime;

    public Material[] goldMaterial = new Material[2];
    public Material[] redMaterial = new Material[2];

    //返回一个地图上合理的位置
    private Vector3 randomPositionVec3()
    {
        return new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
    }

    //对敌人坦克进行加强
    private GameObject tankPowerUp(GameObject tank, float upLevel)
    {
        tank.GetComponent<NavMeshAgent>().speed += 5 * upLevel;
        tank.GetComponent<NavMeshAgent>().acceleration += 5 * upLevel;
        tank.GetComponent<TankAttackTeki2>().tankAttackGapTime -= 0.2f * upLevel;
        return tank;
    }

    void Start()
    {
        curStage = liveTeki = 0;
        freezeState = mutekiState = OFF;
        stageCurTime = Time.time;
        stageLastTime = stageCurTime - stageGapTime + 1;
        playerObject = GameObject.Find("Tank1");
        mutekiBeforeHP = playerObject.GetComponent<TankHealth>().HP;
    }

    void Update()
    {
        //更新血量，为无敌状态做准备
        mutekiBeforeHP = System.Math.Min(mutekiBeforeHP, playerObject.GetComponent<TankHealth>().HP);
        //判断是否应该解除冰冻状态
        if (freezeState == ON && Time.time - freezeStartTime > freezeLastingTime)
            unfreeze();
        //判断是否应该解除无敌状态
        if (mutekiState == ON && Time.time - mutekiStartTime > mutekiLastingTime)
            unmuteki();
        //判断是否应该进入下一关卡
        stageCurTime = Time.time;
        if (stageCurTime - stageLastTime < stageGapTime && liveTeki != 0)
            return;
        stageLastTime = Time.time;
        curStage ++;

        //根据不同阶段添加敌人
        if (curStage == 1)
        {
            liveTeki += 2;
            for(int i = 0; i < 1; i ++)
                tankTeki_1_List.Add(GameObject.Instantiate(tankTeki1, randomPositionVec3(), playerObject.transform.rotation) as GameObject);

            for (int i = 0; i < 1; i++)
                tankTeki_2_List.Add(GameObject.Instantiate(tankTeki2, randomPositionVec3(), playerObject.transform.rotation) as GameObject);
        }
        else if (curStage == 2)
        {
            liveTeki += 3;
            for (int i = 0; i < 2; i++)
                tankTeki_1_List.Add(GameObject.Instantiate(tankTeki1, randomPositionVec3(), playerObject.transform.rotation) as GameObject);

            for (int i = 0; i < 1; i++)
                tankTeki_2_List.Add(GameObject.Instantiate(tankTeki2, randomPositionVec3(), playerObject.transform.rotation) as GameObject);
        }
        else if (curStage == 3)
        {
            liveTeki += 4;
            for (int i = 0; i < 2; i++)
                tankTeki_1_List.Add(GameObject.Instantiate(tankTeki1, randomPositionVec3(), playerObject.transform.rotation) as GameObject);

            for (int i = 0; i < 2; i++)
                tankTeki_2_List.Add(GameObject.Instantiate(tankTeki2, randomPositionVec3(), playerObject.transform.rotation) as GameObject);
        }
        else if (curStage == 4)
        {
            liveTeki += 5;

            for (int i = 0; i < 3; i++)
                tankTeki_1_List.Add(GameObject.Instantiate(tankTeki1, randomPositionVec3(), playerObject.transform.rotation) as GameObject);

            for (int i = 0; i < 2; i++)
                tankTeki_2_List.Add(tankPowerUp(GameObject.Instantiate(tankTeki2, randomPositionVec3(), playerObject.transform.rotation), 1) as GameObject);

        }
        else if (curStage == 5)
        {
            liveTeki += 6;

            for (int i = 0; i < 3; i++)
                tankTeki_1_List.Add(GameObject.Instantiate(tankTeki1, randomPositionVec3(), playerObject.transform.rotation) as GameObject);

            for (int i = 0; i < 3; i++)
                tankTeki_2_List.Add(tankPowerUp(GameObject.Instantiate(tankTeki2, randomPositionVec3(), playerObject.transform.rotation), 2) as GameObject);
        }
        else if(curStage >= 6 && liveTeki!=0)
        {
            Debug.Log("Game Over!");
        }
    }

    void freezeFunc()
    {
        //如果已经有冰冻的敌人，解除他们的冰冻状态，开启新一轮冰冻
        if (freezeState == ON)
            unfreeze();
        freezeStartTime = Time.time;
        freezeState = ON;
        //遍历所有一类敌人
        for (int i = 0; i < tankTeki_1_List.Count; i++)
        {
            if (tankTeki_1_List[i] == null)
                continue;
            //找到符合距离范围的
            if (Vector3.Distance(tankTeki_1_List[i].transform.position, playerObject.transform.position) <= freezeDistance)
            {
                //存下标
                tankTeki_1_FreezeIndexList.Add(i);
                //关自动寻路和移动
                tankTeki_1_List[i].GetComponent<NavMeshAgent>().enabled = false;
                tankTeki_1_List[i].GetComponent<TankMovementTeki1>().enabled = false;
            }
        }
        
        //遍历所有二类敌人
        for (int i = 0; i < tankTeki_2_List.Count; i++)
        {
            if (tankTeki_2_List[i] == null)
                continue;
            //找到符合距离范围的
            if (Vector3.Distance(tankTeki_2_List[i].transform.position, playerObject.transform.position) <= freezeDistance)
            {
                //存下标
                tankTeki_2_FreezeIndexList.Add(i);
                //关闭自动射击以及移动和自动寻路
                tankTeki_2_List[i].GetComponent<NavMeshAgent>().enabled = false;
                tankTeki_2_List[i].GetComponent<TankAttackTeki2>().enabled = false;
                tankTeki_2_List[i].GetComponent<TankMovementTeki2>().enabled = false;
            }
        }
    }

    void mutekiFunc()
    {
        mutekiStartTime = Time.time;
        mutekiState = ON;

        //给玩家换上金身
        MeshRenderer[] allChildren = playerObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer child in allChildren)
            child.materials = goldMaterial;
        
        //血量赋值为无穷大
        playerObject.GetComponent<TankHealth>().HP = INF;
    }

    void unmuteki()
    {
        mutekiState = OFF;

        //解除金身
        MeshRenderer[] allChildren = playerObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer child in allChildren)
            child.materials = redMaterial;

        //恢复血量
        playerObject.GetComponent<TankHealth>().HP = mutekiBeforeHP;
    }

    void unfreeze()
    {
        freezeState = OFF;

        //对于一类敌人，恢复自动寻路和移动
        for (int i = 0; i < tankTeki_1_FreezeIndexList.Count; i++)
        {
            if (tankTeki_1_List[tankTeki_1_FreezeIndexList[i]] != null)
            {
                tankTeki_1_List[tankTeki_1_FreezeIndexList[i]].GetComponent<NavMeshAgent>().enabled = true;
                tankTeki_1_List[tankTeki_1_FreezeIndexList[i]].GetComponent<TankMovementTeki1>().enabled = true;
            }
        }
        //对于二类敌人，恢复自动寻路和移动以及射击
        for (int i = 0; i < tankTeki_2_FreezeIndexList.Count; i++)
        {
            if (tankTeki_2_List[tankTeki_2_FreezeIndexList[i]] == null)
                continue;
            tankTeki_2_List[tankTeki_2_FreezeIndexList[i]].GetComponent<NavMeshAgent>().enabled = true;
            tankTeki_2_List[tankTeki_2_FreezeIndexList[i]].GetComponent<TankAttackTeki2>().enabled = true;
            tankTeki_2_List[tankTeki_2_FreezeIndexList[i]].GetComponent<TankMovementTeki2>().enabled = true;
        }
        //清空冰冻下标列表
        tankTeki_1_FreezeIndexList.Clear();
        tankTeki_2_FreezeIndexList.Clear(); 
    }
}
