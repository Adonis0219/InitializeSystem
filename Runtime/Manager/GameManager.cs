using Unity.VisualScripting;
using UnityEngine;

// GameManager�� BaseManager�� ��ӹ޾� �⺻ �Ŵ��� ����� �����մϴ�.
// �ٸ� Manager���� ����ϰ� �ʹٸ� IPullManager�� ��ӹ�������.
// IPullManager�� ��ӹް�, �ʼ� �޼��带 �����ϸ� Initializer���� �ڵ����� �ʱ�ȭ�˴ϴ�.

// InitOrder Attribute�� ���� �ʱ�ȭ ������ ������ �� �ֽ��ϴ�.
// InitOrderAttribute.cs ������ �����Ͽ� ������ ������ �����ϼ���.
[InitOrder(InitOrder.GameManager)]
public class GameManager : BaseManager, IPullManager
{
    // ------- Managers -------
    private DataManager _dataMgr;

    public override void Init()
    {
        // �ʱ�ȭ ����
    }

    private void Start()
    {
        Debug.Log($"Score : {_dataMgr.score}");
    }

    public void PullUseManager()
    {
        _dataMgr = CoreManager.Instance.GetManager<DataManager>();
    }

}
