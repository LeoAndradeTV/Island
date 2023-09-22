using UnityEngine;

public interface ICollectable
{
    void Collect();
    void GainBenefit();
    void SetCollectTransform(Transform collectorTransform);
}
