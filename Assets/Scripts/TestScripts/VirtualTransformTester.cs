using UnityEngine;
using EasyVirtualTransform;

public class VirtualTransformTester : MonoBehaviour
{
    [SerializeField] private Transform child;
    [SerializeField] private Transform betweenChild;

    private VirtualTransform _virtualTransformChild;
    private VirtualTransform _virtualTransformBetweenChild;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _virtualTransformChild = new VirtualTransform(child);
        _virtualTransformChild = new VirtualTransform(betweenChild);
        _virtualTransformChild.Parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        child.position = _virtualTransformChild.Position;
        child.rotation = _virtualTransformChild.Rotation;

        _virtualTransformChild.ShowDebugPose();
    }
}
