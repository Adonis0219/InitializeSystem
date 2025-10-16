using Unity.VisualScripting;
using UnityEngine;

// GameManager는 BaseManager를 상속받아 기본 매니저 기능을 수행합니다.
// 다른 Manager들을 사용하고 싶다면 IPullManager를 상속받으세요.
// IPullManager를 상속받고, 필수 메서드를 구현하면 Initializer에서 자동으로 초기화됩니다.

// InitOrder Attribute를 통해 초기화 순서를 지정할 수 있습니다.
// InitOrderAttribute.cs 파일을 참고하여 적절한 순서를 지정하세요.
[InitOrder(InitOrder.GameManager)]
public class GameManager : BaseManager, IPullManager
{
    // ------- Managers -------
    private DataManager _dataMgr;

    public override void Init()
    {
        // 초기화 로직
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
