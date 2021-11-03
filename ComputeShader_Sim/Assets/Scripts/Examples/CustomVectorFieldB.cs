using System;
using UnityEngine;


public class CustomVectorFieldB : VectorField3 {
    public override Vector3 sample( double x, double y, double z ) {
        return new Vector3(
            ( float )( -Math.Sin( y ) * Math.Cos( z ) ),
            ( float )( -Math.Sin( z ) * Math.Cos( x ) ),
            //( float )( -Math.Sin( x ) * Math.Cos( y ) )
            0
        );
    }
}