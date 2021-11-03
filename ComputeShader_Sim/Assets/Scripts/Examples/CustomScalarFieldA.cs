using System;
using UnityEngine;


public class CustomScalarFieldA : ScalarField3 {
    public override double sample( double x, double y, double z ) {
        return Math.Sin( x ) * Math.Sin( y ) * Math.Sin( z ); ;
    }
}