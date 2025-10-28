using UnityEngine;

[InitOrder(InitOrder.AudioManager)]
public class AudioManager : BaseManager
{
    public AudioClip clip;

    public override void Init()
    {
        // 초기화 로직
    }
}
