using UnityEngine;

// 현재는 본문이 비어있지만, 모든 매니저의 기반이 되는 추상 기본 클래스입니다.
// Unity의 기능을 사용해야 할 수 있으므로 MonoBehaviour를 상속받는 것이 일반적입니다.
// 만약 모든 매니저가 갖는 공통 기능이 생긴다면 예시와 같이 추가하면 됩니다.
public abstract class BaseManager : MonoBehaviour, IInitializable
{
    // 예시 : 모든 '매니저'가 가져야 할 초기화 메서드
    // public abstract void InitializeManager();

    public abstract void Init();
}
