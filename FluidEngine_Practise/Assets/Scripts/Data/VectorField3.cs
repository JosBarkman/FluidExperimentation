using UnityEngine;


public abstract class VectorField3 : Field3 {
    public abstract Vector3 sample( double x, double y, double z );
}