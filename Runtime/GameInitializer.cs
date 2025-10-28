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

        var coreSystemPrefab = Resources.Load<GameObject>("[CoreSystem]");

        if (coreSystemPrefab != null)
        {
            var coreSystemObject = Instantiate(coreSystemPrefab);

            coreSystemObject.name = coreSystemPrefab.name;
        }
        else
        {
            GameLogger.LogError("Resources 폴더에서 [CoreSystem] 프리팹을 찾을 수 없습니다.");
        }
    }
}
