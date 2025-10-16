using UnityEngine;

public interface IInitializable
{
    // �ʼ������� ����
    // �߻� �޼��� (�������̽��̹Ƿ� abstract Ű���� ����)
    public void Init();
    
    // �ʿ� �� ����
    // �⺻ �������̽� �޼��� (Ŭ������ virtual ���� �޼���� ������ ���)
    public void PostInit() {}

    // �߻� �޼���
    // public void PostInit();
}