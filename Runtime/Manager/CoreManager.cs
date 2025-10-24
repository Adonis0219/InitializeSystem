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
            GameLogger.LogError("Initializer�� ���� �������� �ʽ��ϴ�. CoreManager�� �Ŵ������� ����� �� �����ϴ�.");
    }

    public void RegisterManagers(IEnumerable<IInitializable> initializables)
    {
        managers = initializables.OfType<BaseManager>().ToList();

        NotifyPullManagers();

        GameLogger.Log("CoreManager : �Ŵ������� ��ϵǾ����ϴ�.");
    }

    void NotifyPullManagers()
    {
        var pullables = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
            .OfType<IPullManager>();

        foreach (var p in pullables) p.PullUseManager();
    }

    // ���׸� T�� class, IManager�� �� �� ���� ���·θ� ����
    /// <summary>
    /// CoreManager.instance.managerInstances�� �����ϸ� IManager ���·� ��ȯ�ȴ�.
    /// �̿� ���� �߰����� ����ȯ�� ���ϱ� ����
    /// </summary>
    /// <typeparam name="T">��ȯ���� �Ŵ��� Ÿ��</typeparam>
    /// <returns>��ȯ���� �Ŵ���</returns>
    public T GetManager<T>() where T : BaseManager
    {
        if (managers.Count == 0)
        {
            GameLogger.LogError($"�Ŵ������� �ʱ�ȭ �Ǳ� ���Դϴ�. ���� ������ �������ּ���!");

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
        
        // FirstOrDefalut : Ű�� �ش��ϴ� ù��° �� �Ǵ� �⺻���� �������ش� -> ���� �������� ������ null
        // m => m is T : TŸ���� IManager m�� ��ȯ (is ����ȯ : ����ȯ ���� �Ұ��� ����)
        // IManager as T -> �־��� ���׸� ������ IManager ����ȯ (as ����ȯ : �����ϸ� ĳ���� �Ұ����ϸ� null)
        return managers.FirstOrDefault(m => m is T) as T;
    }
}