using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public event Action<IEnumerable<IInitializable>> OnSortComplete;

    // 정렬된 객체들을 담아줄 리스트
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
        
        // 1. Attribute가 있는지 검사 후 리스트에 넣기
        foreach (var initializable in initializables)
        {
            var att = initializable.GetType().GetCustomAttribute<InitOrderAttribute>();

            if (att == null)
            {
                GameLogger.LogError($"{initializable.GetType().Name}에 클래스에서 [InitOrder] Attribute를 설정해주지 않았습니다. " +
                               $"초기화 순서를 명시해주세요!");
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif

                return;
            }
            
            initList.Add(initializable);
        }
        
        // 2. 검증이 완료된 리스트만 정렬 후 초기화 진행
        // att가 null일 수 없으므로 ?. ?? 연산자 불필요
        sorted = initList.OrderBy(o => 
            o.GetType().GetCustomAttribute<InitOrderAttribute>().OrderIndex).ToList();

        // 모든 객체들의 초기화를 시작하기 전 CoreManager에게 정렬된 매니저 목록 넘겨주기
        // 1. CoreManager 인스턴스 직접 참조
        // CoreManager.instance.RegisterManagers(sorted);
        // 2. Action을 통해 알려주기
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
        // PostInitialize 패턴
        foreach (var initializable in sorted)
        {
            initializable.PostInit();

#if UNITY_EDITOR
            GameLogger.Log($"[PostInit] Initialized: {initializable.GetType().Name}");
#endif
        }
    }
}

// 초기화 순서 정해주기

// 2. Custom Attribute 추가
