using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

    SlotManager 에서 시작 색상 셋팅
 
 */
public class SlotManager : MonoSingleton3<SlotManager>
{
    public enum eState
    {
        영 = 0,
        일,
        이,
        삼,
        사,
        오,
        육,
        칠,
        팔,
        구,
        십,
        십일,
        십이,
        십삼,
        십사,
        십오,
        십육,
        십칠,
        십팔,
        십구,
        이십,
        이십일,

    }

    // 열거형 족보
    public eState state;

    [Header("각 열의 회전 시간")]
    public float[] spinTime;
    [Header("각 열의 속도")]
    public float[] SlotSpeed;

    // SlotComponent 배열
    public csSlotComponent[] slotComponentList;
    // 슬롯 이미지수
    public int slotImageCount;
}
