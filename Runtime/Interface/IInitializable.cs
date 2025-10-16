using UnityEngine;

public interface IInitializable
{
    // 필수적으로 구현
    // 추상 메서드 (인터페이스이므로 abstract 키워드 생략)
    public void Init();
    
    // 필요 시 구현
    // 기본 인터페이스 메서드 (클래스의 virtual 가상 메서드와 동일한 기능)
    public void PostInit() {}

    // 추상 메서드
    // public void PostInit();
}