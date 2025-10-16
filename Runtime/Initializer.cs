using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public event Action<IEnumerable<IInitializable>> OnSortComplete;

    // ���ĵ� ��ü���� ����� ����Ʈ
    private List<IInitializable> sorted;
    
    private void Awake()
    {
        Init();
        PostInit();
    }

    void Init()
    {
        var initializables = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .OfType<IInitializable>();

        var initList = new List<IInitializable>();
        
        // 1. Attribute�� �ִ��� �˻� �� ����Ʈ�� �ֱ�
        foreach (var initializable in initializables)
        {
            var att = initializable.GetType().GetCustomAttribute<InitOrderAttribute>();

            if (att == null)
            {
                GameLogger.LogError($"{initializable.GetType().Name}�� Ŭ�������� [InitOrder] Attribute�� ���������� �ʾҽ��ϴ�. " +
                               $"�ʱ�ȭ ������ ������ּ���!");
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif

                return;
            }
            
            initList.Add(initializable);
        }
        
        // 2. ������ �Ϸ�� ����Ʈ�� ���� �� �ʱ�ȭ ����
        // att�� null�� �� �����Ƿ� ?. ?? ������ ���ʿ�
        sorted = initList.OrderBy(o => 
            o.GetType().GetCustomAttribute<InitOrderAttribute>().OrderIndex).ToList();

        // ��� ��ü���� �ʱ�ȭ�� �����ϱ� �� CoreManager���� ���ĵ� �Ŵ��� ��� �Ѱ��ֱ�
        // 1. CoreManager �ν��Ͻ� ���� ����
        // CoreManager.instance.RegisterManagers(sorted);
        // 2. Action�� ���� �˷��ֱ�
        OnSortComplete?.Invoke(sorted);

        foreach (var initializable in sorted)
        {
            initializable.Init();

#if UNITY_EDITOR
            GameLogger.Log($"[Init] Initialized: {initializable.GetType().Name}");
#endif
        }
    }

    void PostInit()
    {
        // PostInitialize ����
        foreach (var initializable in sorted)
        {
            initializable.PostInit();

#if UNITY_EDITOR
            GameLogger.Log($"[PostInit] Initialized: {initializable.GetType().Name}");
#endif
        }
    }
}

// �ʱ�ȭ ���� �����ֱ�

// 2. Custom Attribute �߰�
