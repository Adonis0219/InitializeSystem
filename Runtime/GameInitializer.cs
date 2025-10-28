using System;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// 게임 시작 시 첫 씬이 로드되기 전에 자동으로 호출되는 메서드
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeCoreSystem()
    {
        if (FindAnyObjectByType<CoreManager>() || FindAnyObjectByType<Initializer>())
        {
            GameLogger.Log("이미 CoreSystem 객체가 존재합니다.");
            return;
        }

        var settings = Resources.Load<CoreSystemSettings>("CoreSystemSettings");

        if (settings != null)
        {
            GameLogger.LogError("CoreSystemSettings 에셋을 찾을 수 없습니다.");
        }

        if (settings.coreSystemPrefab == null)
        {
            GameLogger.LogError("CoreSystemSettings 에셋에 프리팹을 할당해주세요.");
        }

        var coreSystemObj = Instantiate(settings.coreSystemPrefab);
        coreSystemObj.name = settings.coreSystemPrefab.name;
    }
}
