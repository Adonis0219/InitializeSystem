using UnityEngine;

// DataManager�� BaseManager�� ��ӹ޾� �⺻ �Ŵ��� ����� �����մϴ�.
// InitOrder Attribute�� ���� �ʱ�ȭ ������ ������ �� �ֽ��ϴ�. (�ʼ�)
[InitOrder(InitOrder.DataManager)]
public class DataManager : BaseManager
{
    public int score = 100;

    public override void Init()
    {
        // �ʱ�ȭ ����
    }
}
