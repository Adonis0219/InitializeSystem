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

        var coreSystemPrefab = Resources.Load<GameObject>("[CoreSystem]");

        if (coreSystemPrefab != null)
        {
            var coreSystemObject = Instantiate(coreSystemPrefab);

            coreSystemObject.name = coreSystemPrefab.name;
        }
        else
        {
            GameLogger.LogError("Resources �������� [CoreSystem] �������� ã�� �� �����ϴ�.");
        }
    }
}
