using System;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    /// <summary>
    /// ���� ���� �� ù ���� �ε�Ǳ� ���� �ڵ����� ȣ��Ǵ� �޼���
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeCoreSystem()
    {
        if (FindAnyObjectByType<CoreManager>() || FindAnyObjectByType<Initializer>())
        {
            GameLogger.Log("�̹� CoreSystem ��ü�� �����մϴ�.");
            return;
        }

        var settings = Resources.Load<CoreSystemSettings>("CoreSystemSettings");

        if (settings != null)
        {
            GameLogger.LogError("CoreSystemSettings ������ ã�� �� �����ϴ�.");
        }

        if (settings.coreSystemPrefab == null)
        {
            GameLogger.LogError("CoreSystemSettings ���¿� �������� �Ҵ����ּ���.");
        }

        var coreSystemObj = Instantiate(settings.coreSystemPrefab);
        coreSystemObj.name = settings.coreSystemPrefab.name;
    }
}
