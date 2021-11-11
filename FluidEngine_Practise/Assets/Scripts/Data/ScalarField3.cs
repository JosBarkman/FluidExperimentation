using UnityEngine;


public abstract class ScalarField3 : Field3 {
    public abstract double sample( double x, double y, double z );
}