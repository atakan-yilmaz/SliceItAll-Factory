using EzySlice;
using UnityEngine;

public class SliceObject : MonoBehaviour
{
    public Material[] materialSlicedSlice;
    public float explosionForce;
    public float exposionRadius;
    public bool gravity, kinematic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CanSlice"))
        {
            SlicedHull sliceObj = Slice(other.gameObject, materialSlicedSlice[Random.Range(0, materialSlicedSlice.Length)]);
            if (sliceObj !=null)
            {
                GameObject slicedObjTop = sliceObj.CreateUpperHull(other.gameObject, materialSlicedSlice[Random.Range(0, materialSlicedSlice.Length)]);
                GameObject slicedObjDown = sliceObj.CreateLowerHull(other.gameObject, materialSlicedSlice[Random.Range(0, materialSlicedSlice.Length)]);
                Destroy(other.gameObject);
                AddComponent(slicedObjTop);
                AddComponent(slicedObjDown);
                Destroy(slicedObjTop, 2f);
                Destroy(slicedObjDown, 2f);
                slicedObjTop.GetComponent<Rigidbody>().useGravity = true;
                slicedObjDown.GetComponent<Rigidbody>().useGravity = true;
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