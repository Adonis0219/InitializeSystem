using UnityEngine;

// IPullManager�� ��ӹ��� Ŭ������ IInitializable �������̽��� �ʼ������� ��ӹ޾ƾ� ��
public interface IPullManager : IInitializable
{
    public void PullUseManager();

    // PullUseManager�� PostInit���� �ʼ������� ȣ���
    void IInitializable.PostInit()
    {
        PullUseManager();
    }
}
