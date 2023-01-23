using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsControllar : MonoBehaviour
{
    public GameObject AttackRange;  
    public GameObject AttackArea;
    public GameObject SkillRange;
    public GameObject SkillArea;
    public GameObject MoveRange;
    public GameObject MoveArea;

    //Attackの射程にRangeプレハブ設置
    public void SetAttackRange(int x,int y)
    {
        float xs = (float)x - 6.0f;
        float ys = (float)y - 6.0f;
        Instantiate(AttackRange, new Vector3(xs, ys, 0), Quaternion.identity);
    }
    //Attack効果範囲areaにプレハブ設置
    public void SetAttackArea(int x,int y)
    {
        float xs = (float)x - 6.0f;
        float ys = (float)y - 6.0f;
        Instantiate(AttackArea, new Vector3(xs, ys, 0), Quaternion.identity);
    }

    //Skillの射程にRangeプレハブ設置
    public void SetSkillRange(int x,int y)
    {
        float xs = (float)x - 6.0f;
        float ys = (float)y - 6.0f;
        Instantiate(SkillRange, new Vector3(xs, ys, 0), Quaternion.identity);
    }
    //Skill効果範囲にareaプレハブ設置
    public void SetSkillArea(int x,int y)
    {
        float xs = (float)x - 6.0f;
        float ys = (float)y - 6.0f;
        Instantiate(SkillArea, new Vector3(xs, ys, 0), Quaternion.identity);
    }

    //Moveの射程にRangeプレハブ設置
    public void SetMoveRange(int x,int y){
        float xs= (float)x - 6.0f;
        float ys= (float)y - 6.0f;
        Instantiate(MoveRange,new Vector3(xs,ys,0),Quaternion.identity);
    }
    //Moveの効果範囲にareaプレハブ設置
    public void SetMoveArea(int x,int y){
        float xs= (float)x - 6.0f;
        float ys= (float)y - 6.0f;
        Instantiate(MoveArea,new Vector3(xs,ys,0),Quaternion.identity);
    }

    //Rangeクローン削除関数
    public void DeleteRangeClone(){
        //クローン削除
        var clones = GameObject.FindGameObjectsWithTag ("Range");
        foreach(var clone in clones){
            Destroy(clone);
        }
    }

    //Areaクローン削除
    public void DeleteAreaClone(){
        //クローン削除
        var clones = GameObject.FindGameObjectsWithTag ("Area");
        foreach(var clone in clones){
            Destroy(clone);
        }
    }
}

