using UnityEngine;


public abstract class ScalarField3 : MonoBehaviour {
    public abstract double sample( double x, double y, double z );
}