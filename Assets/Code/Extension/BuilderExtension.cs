using UnityEngine;

namespace Code
{
    public static partial class BuilderExtension
    {
        public static GameObject AddMesh(this GameObject gameObject, Mesh mesh)
        {
            var component = gameObject.GetOrAddComponent<MeshFilter>();
            component.mesh = mesh;
            return gameObject;
        }

        public static GameObject AddMeshRenderer(this GameObject gameObject, Material playerMaterial)
        {
            var component = gameObject.GetOrAddComponent<MeshRenderer>();
            component.materials[0] = playerMaterial;
            return gameObject;
        }

        public static GameObject AddSphereCollider(this GameObject gameObject)
        {
            var component = gameObject.GetComponent<SphereCollider>();
            component.radius = 0.5f;
            return gameObject;
        }

        public static GameObject AddRigidBody(this GameObject gameObject, float mass, float angularDrag)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            component.angularDrag = angularDrag;
            return gameObject;
        }


        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}