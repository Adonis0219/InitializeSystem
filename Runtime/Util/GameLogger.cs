using System.Diagnostics;

// 해당 스크립트의 메서드들은 유니티 에디터 또는 개발 빌드(Development Build)에서만 실행됩니다.
// 최종 릴리즈 빌드에서는 포함되지 않아 성능에 영향을 주지 않습니다.
public static class GameLogger
{
    // Conditional 어트리뷰트에 대한 자세한 설명은 아래 노션 페이지의 5번 항목을 참고해주세요
    // https://www.notion.so/26cb1f49203e8098a26ae89bf84a9d54?source=copy_link
    
    /// <summary>
    /// Conditional Attribute에 대한 자세한 내용은
    /// <see href="https://www.notion.so/26cb1f49203e8098a26ae89bf84a9d54?source=copy_link">5번 항목</see>를 참고하세요.
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    /// <summary>
    /// Conditional Attribute에 대한 자세한 내용은
    /// <see href="https://www.notion.so/26cb1f49203e8098a26ae89bf84a9d54?source=copy_link">5번 항목</see>를 참고하세요.
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void LogWarning(object message)
    {
        UnityEngine.Debug.Log(message);
    }
    
    /// <summary>
    /// Conditional Attribute에 대한 자세한 내용은
    /// <see href="https://www.notion.so/26cb1f49203e8098a26ae89bf84a9d54?source=copy_link">5번 항목</see>를 참고하세요.
    /// </summary>
    [Conditional("UNITY_EDITOR")]
    [Conditional("DEVELOPMENT_BUILD")]
    public static void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);

#if UNITY_EDITIOR
        UnityEditor.EditorApplication.isPaused = true;
#endif
    }
}