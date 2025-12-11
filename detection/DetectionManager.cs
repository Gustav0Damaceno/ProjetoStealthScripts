using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    UIDetectionBar bar;
    EnemyDetection[] enemies;

    void Start()
    {
        bar = FindObjectOfType<UIDetectionBar>();
    }

    void Update()
    {
        enemies = FindObjectsOfType<EnemyDetection>();

        float maior = 0f;

        foreach (var e in enemies)
        {
            float porcentagem = e.detection / e.fullDetection;

            if (porcentagem > maior)
                maior = porcentagem;
        }

        bar.SetDetection(maior);
    }
}
