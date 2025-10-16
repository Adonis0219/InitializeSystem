using System;
using UnityEngine;

public static class InitOrder
{
	// 'const'�� ����� ����� ������ ������ �̹� ���� �����Ǹ�,
	// ���������� 'static' ���ó�� �����ϱ� ������ (�Ͻ��� static)
	public const int T = int.MinValue;

    // ī�װ� ���� ����
    [Header("# Category")]
    private const int System  = 0;
    private const int Manager = 100;
    private const int Player  = 200;
    private const int Object  = 300;
    private const int UI      = 400;
    // ���ο� ī�װ� �ʿ� �� ���� �߰� (Ex. private const int ~ = 400;
    
    // ī�װ��� �ε��� ����
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
    // ���� 1
    public const int Item       = Object + 3;
    
    // ���� 2
    [Header("# UI")]
    public const int ResultUI = UI + 0;
}

public class InitOrderAttribute : Attribute
{
    public int OrderIndex { get; }

    public InitOrderAttribute(int order)
    {
        // Setter�� ������ �������, ������ ���ο����� �ʱ�ȭ ����
        // set�� ���ִ� �� �ƴ� �ʱ�ȭ �����̶� �ٸ���
        // �����Ϸ��� ���������� �����ִ� 'readonly' �ʵ��� ���� '�ʱ�ȭ(Initialize)'�ϴ� ����!!!
        OrderIndex = order;
    }
}
