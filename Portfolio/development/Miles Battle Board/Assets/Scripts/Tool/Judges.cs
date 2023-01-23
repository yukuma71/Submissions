using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Judges : MonoBehaviour
{

    public Flag Flag;

    private static bool mp_judge;    //MPが足りているか
    private static bool judge;      //ジャッジの結果

    


    //masuの範囲内か判断
    public bool withinRangeJudge(int coordinate){
        return judge = (MAP_SIZE_MAX >= coordinate && MAP_SIZE_MIN <= coordinate)? true:false;
        
    }

    //味方か
    public bool FriendJudge(int plnum){
        return false;
    }

    //MPが足りているか
    public void SetMpJudge(int mp, int need_mp){
        judge = (mp >= need_mp)? true:false;
        Flag.SetMpFlag(judge);
    }

    //JobNumからジョブ名を返答
    public static string GetJobName(int jobnum){
        string job_name = "";
        switch(jobnum)
        {
            case 1:
                job_name = "戦士";
                break;
            case 2:
                job_name = "騎士";
                break;
            case 3:
                job_name = "僧侶";
                break;
            case 4:
                job_name = "魔女";
                break;
        }
        return job_name;
    }

}
