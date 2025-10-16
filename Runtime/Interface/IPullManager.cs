using UnityEngine;

// IPullManager를 상속받은 클래스는 IInitializable 인터페이스를 필수적으로 상속받아야 함
public interface IPullManager : IInitializable
{
    public void PullUseManager();

    // PullUseManager는 PostInit에서 필수적으로 호출됨
    void IInitializable.PostInit()
    {
        PullUseManager();
    }
}
