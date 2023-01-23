using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public const int SENSHI = 1, KISHI = 2, SOURYO = 3, MAJO = 4; //job番号
    public const byte MAP_SIZE_MIN = 0;  //HACK:MASU 547以降
    public const byte MAP_SIZE_MAX = 12; //配列に用いるため-1HACK:MASU 547以降

    //スキルの射程
    public const byte KISHI_SKILL_RANGE = 1;
    public const byte SOURYO_SKILL_RANGE = 1;
    public const byte MAJO_SKILL_RANGE = 3;
}
