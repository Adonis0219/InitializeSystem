using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[InitOrder(InitOrder.CoreManager)]
public class CoreManager : Singleton<CoreManager>
{
    private List<BaseManager> managers;
    
    // [Header("# Main Entity")]
    // public Player player;

    protected override void Awake()
    {
        base.Awake();

        LinkToAction();
    }

    private void LinkToAction()
    {
        Initializer initializer = FindFirstObjectByType<Initializer>();

        if (initializer != null)
            initializer.OnSortComplete += RegisterManagers;
        else
            GameLogger.LogError("Initializer가 씬에 존재하지 않습니다. CoreManager가 매니저들을 등록할 수 없습니다.");
    }

    public void RegisterManagers(IEnumerable<IInitializable> initializables)
    {
        managers = initializables.OfType<BaseManager>().ToList();

        NotifyPullManagers();

        GameLogger.Log("CoreManager : 매니저들이 등록되었습니다.");
    }

    void NotifyPullManagers()
    {
        var pullables = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .OfType<IPullManager>();

        foreach (var p in pullables) p.PullUseManager();
    }

    // 제네릭 T를 class, IManager를 둘 다 가진 형태로만 한정
    /// <summary>
    /// CoreManager.instance.managerInstances로 접근하면 IManager 형태로 반환된다.
    /// 이에 따른 추가적인 형변환을 피하기 위해
    /// </summary>
    /// <typeparam name="T">반환해줄 매니저 타입</typeparam>
    /// <returns>반환해줄 매니저</returns>
    public T GetManager<T>() where T : BaseManager
    {
        if (managers.Count == 0)
        {
            GameLogger.LogError($"매니저들이 초기화 되기 전입니다. 접근 로직을 수정해주세요!");

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        
        // FirstOrDefalut : 키에 해당하는 첫번째 값 또는 기본값을 가져와준다 -> 값이 존재하지 않으면 null
        // m => m is T : T타입의 IManager m을 반환 (is 형변환 : 형변환 가능 불가능 여부)
        // IManager as T -> 넣어준 제네릭 값으로 IManager 형변환 (as 형변환 : 가능하면 캐스팅 불가능하면 null)
        return managers.FirstOrDefault(m => m is T) as T;
    }
}