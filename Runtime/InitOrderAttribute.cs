using System;
using UnityEngine;

public static class InitOrder
{
	// 'const'로 선언된 상수는 컴파일 시점에 이미 값이 결정되며,
	// 본질적으로 'static' 멤버처럼 동작하기 때문에 (암시적 static)
	public const int T = int.MinValue;

    // 카테고리 직접 설정
    [Header("# Category")]
    private const int System  = 0;
    private const int Manager = 100;
    private const int Player  = 200;
    private const int Object  = 300;
    private const int UI      = 400;
    // 새로운 카테고리 필요 시 직접 추가 (Ex. private const int ~ = 400;
    
    // 카테고리별 인덱스 설정
    [Header("# System")]
    public const int Logger  = System + 0;
    public const int BackEnd = System + 1;

    [Header("# Manager")]
    public const int CoreManager  = Manager + 0;
    public const int GameManager  = Manager + 1;
    public const int DataManager  = Manager + 2;
    public const int AudioManager = Manager + 3;
    public const int StageManager = Manager + 4;
    public const int ScoreManager = Manager + 5;
    public const int FuelManager  = Manager + 6;
    //public const int TestManager  = Manager + 7;

    [Header("# Player")]
    public const int PlayerBase     = Player + 0;
    public const int PlayerCollider = Player + 1;
    //public const int PlayerTest     = Player + 2;

    [Header("# Object")]
    public const int Obstacle   = Object + 1;
    public const int DontDesObs = Object + 2;
    // 예시 1
    public const int Item       = Object + 3;
    
    // 예시 2
    [Header("# UI")]
    public const int ResultUI = UI + 0;
}

public class InitOrderAttribute : Attribute
{
    public int OrderIndex { get; }

    public InitOrderAttribute(int order)
    {
        // Setter가 없더라도 선언시점, 생성자 내부에서는 초기화 가능
        // set을 해주는 게 아닌 초기화 개념이라 다르다
        // 컴파일러가 내부적으로 숨어있는 'readonly' 필드의 값을 '초기화(Initialize)'하는 과정!!!
        OrderIndex = order;
    }
}
