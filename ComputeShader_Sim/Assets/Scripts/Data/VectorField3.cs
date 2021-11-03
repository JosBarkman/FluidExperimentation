using UnityEngine;


public abstract class VectorField3 : MonoBehaviour {
    public abstract Vector3 sample( double x, double y, double z );
}