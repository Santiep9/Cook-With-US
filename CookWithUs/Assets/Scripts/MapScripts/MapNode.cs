using UnityEngine;
using UnityEngine.UI;

public class MapNode : MonoBehaviour
{
    public int sceneId;

    public GameObject visualObject;

    [Range(0f, 1f)] public float blockedAlpha = 0.4f;
    [Range(0f, 1f)] public float availableAlpha = 1f;

    private SpriteRenderer sr;

    void Start()
    {
        sr = visualObject.GetComponent<SpriteRenderer>();

        bool unlocked = CityGameManager.Instance.unlockedScenes[sceneId];
        bool active = CityGameManager.Instance.activeScene == sceneId;

        float alpha = (unlocked || active) ? availableAlpha : blockedAlpha;

        SetAlpha(alpha);
    }

    void SetAlpha(float alpha)
    {
        if (sr != null)
        {
            Color c = sr.color;
            c.a = alpha;
            sr.color = c;
        }
    }
}