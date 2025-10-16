using UnityEngine;

// ����� ������ ���������, ��� �Ŵ����� ����� �Ǵ� �߻� �⺻ Ŭ�����Դϴ�.
// Unity�� ����� ����ؾ� �� �� �����Ƿ� MonoBehaviour�� ��ӹ޴� ���� �Ϲ����Դϴ�.
// ���� ��� �Ŵ����� ���� ���� ����� ����ٸ� ���ÿ� ���� �߰��ϸ� �˴ϴ�.
public abstract class BaseManager : MonoBehaviour, IInitializable
{
    // ���� : ��� '�Ŵ���'�� ������ �� �ʱ�ȭ �޼���
    // public abstract void InitializeManager();

    public abstract void Init();
}
