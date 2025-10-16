using UnityEngine;

// DataManager는 BaseManager를 상속받아 기본 매니저 기능을 수행합니다.
// InitOrder Attribute를 통해 초기화 순서를 지정할 수 있습니다. (필수)
[InitOrder(InitOrder.DataManager)]
public class DataManager : BaseManager
{
    public int score = 100;

    public override void Init()
    {
        // 초기화 로직
    }
}
