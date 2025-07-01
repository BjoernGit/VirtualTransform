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
        //creation of  VirtualTransforms on the basis of an actual Transform
        _virtualTransformChild = new VirtualTransform(child);
        _virtualTransformBetweenChild = new VirtualTransform(betweenChild);

        //parenting to an actual Transform
        _virtualTransformBetweenChild.Parent = transform;
        //parenting to a VirtualTransform
        _virtualTransformChild.Parent = _virtualTransformBetweenChild;
    }

    // Update is called once per frame
    void Update()
    {
        //Setting of the VirtualkTransform position to the Transform to actually move it
        child.position = _virtualTransformChild.Position;
        child.rotation = _virtualTransformChild.Rotation;

        //VirtualTransforms only recalculate on request
        _virtualTransformChild.ShowDebugPose();
        _virtualTransformBetweenChild.ShowDebugPose();
    }
}
