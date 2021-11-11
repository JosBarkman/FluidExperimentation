using System;
using UnityEngine;


public class CustomVectorFieldA : VectorField3 {
    public override Vector3 sample( double x, double y, double z ) {
        return new Vector3(
            ( float )( Math.Cos( x ) * Math.Sin( y ) * Math.Sin( z ) ),
            ( float )( Math.Sin( x ) * Math.Cos( y ) * Math.Sin( z ) ),
            ( float )( Math.Sin( x ) * Math.Sin( y ) * Math.Cos( z ) )
        );
    }
}