using EzySlice;
using UnityEngine;

public class SliceObject : MonoBehaviour
{
    public Material materialSlicedSlice;
    public float explosionForce;
    public float exposionRadius;
    public bool gravity, kinematic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            SlicedHull sliceObj = Slice(other.gameObject, materialSlicedSlice);
            if (sliceObj !=null)
            {
                GameObject slicedObjTop = sliceObj.CreateUpperHull(other.gameObject, materialSlicedSlice);
                GameObject slicedObjDown = sliceObj.CreateLowerHull(other.gameObject, materialSlicedSlice);
                Destroy(other.gameObject);
                AddComponent(slicedObjTop);
                AddComponent(slicedObjDown);
            }
           
        }
    }

    private SlicedHull Slice(GameObject obj, Material mat)
    {
        return obj.Slice(transform.position, transform.up, mat);
    }

    void AddComponent (GameObject obj)
    {
        obj.AddComponent<BoxCollider>();
        var rigidbody = obj.AddComponent<Rigidbody>();
        rigidbody.useGravity = gravity;
        rigidbody.isKinematic = kinematic;
        rigidbody.AddExplosionForce(explosionForce, obj.transform.position, exposionRadius);
        obj.tag = "CanSlice";
    }
}