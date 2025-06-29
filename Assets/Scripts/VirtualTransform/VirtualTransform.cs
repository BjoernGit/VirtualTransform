using UnityEngine;

namespace EasyVirtualTransform
{
    public class VirtualTransform
    {
        private Vector3 _localPosition;
        private Quaternion _localRotation;
        private object _parent;

        public Vector3 LocalPosition
        {
            get => _localPosition;
            set => _localPosition = value;
        }

        public Quaternion LocalRotation
        {
            get => _localRotation;
            set => _localRotation = value;
        }

        public Vector3 Position
        {
            get
            {
                if (_parent == null)
                    return _localPosition;

                if (_parent is Transform t)
                    return t.position + t.rotation * _localPosition;

                if (_parent is VirtualTransform vt)
                    return vt.Position + vt.Rotation * _localPosition;

                return _localPosition;
            }
            set
            {
                if (_parent == null)
                {
                    _localPosition = value;
                    return;
                }

                if (_parent is Transform t)
                {
                    _localPosition = Quaternion.Inverse(t.rotation) * (value - t.position);
                    return;
                }

                if (_parent is VirtualTransform vt)
                {
                    _localPosition = Quaternion.Inverse(vt.Rotation) * (value - vt.Position);
                    return;
                }

                _localPosition = value;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                if (_parent == null)
                    return _localRotation;

                if (_parent is Transform t)
                    return t.rotation * _localRotation;

                if (_parent is VirtualTransform vt)
                    return vt.Rotation * _localRotation;

                return _localRotation;
            }
            set
            {
                if (_parent == null)
                {
                    _localRotation = value;
                    return;
                }

                if (_parent is Transform t)
                {
                    _localRotation = Quaternion.Inverse(t.rotation) * value;
                    return;
                }

                if (_parent is VirtualTransform vt)
                {
                    _localRotation = Quaternion.Inverse(vt.Rotation) * value;
                    return;
                }

                _localRotation = value;
            }
        }

        public object Parent
        {
            get => _parent;
            set
            {
                if (value is Transform || value is VirtualTransform || value == null)
                    _parent = value;
                else
                    throw new System.ArgumentException("Parent must be either Transform or VirtualTransform");
            }
        }

        public VirtualTransform(Transform transform)
        {
            _parent = null;
            _localPosition = transform.position;
            _localRotation = transform.rotation;
        }

        public VirtualTransform(VirtualTransform transform)
        {
            _parent = null;
            _localPosition = transform.Position;
            _localRotation = transform.Rotation;
        }

        public VirtualTransform(Vector3 localPosition, Quaternion localRotation)
        {
            _localPosition = localPosition;
            _localRotation = localRotation;
            _parent = null;
        }
    }
}