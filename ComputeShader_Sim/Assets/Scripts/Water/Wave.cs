using System;
using System.Collections.Generic;
using UnityEngine;


public class Wave {
    public static Wave zero {
        get {
            return new Wave( 0.0, 0.0, 0.0, 0.0 );
        }
    }


    public override bool Equals( object w ) {
        if ( null != w && w is Wave ) {
            Wave wave = w as Wave;
            return ( waveLength == wave.waveLength &&
                     maxHeight == wave.maxHeight &&
                     location == wave.location &&
                     velocity == wave.velocity );
        }
        else return false;
    }


    public static bool operator ==( Wave lhs, Wave rhs ) {
        return ( lhs.waveLength == rhs.waveLength &&
                 lhs.maxHeight == rhs.maxHeight &&
                 lhs.location == rhs.location &&
                 lhs.velocity == rhs.velocity );
    }


    public static bool operator !=( Wave lhs, Wave rhs ) {
        return !( lhs.waveLength == rhs.waveLength &&
                 lhs.maxHeight == rhs.maxHeight &&
                 lhs.location == rhs.location &&
                 lhs.velocity == rhs.velocity );
    }


    private static int bufferSize = 80;
    public double waveLength;
    public double maxHeight;
    public double location;
    public double velocity;




    public Wave( double pWaveLength, double pMaxHeight, double pLocation, double pVelocity ) {
        waveLength = pWaveLength;
        maxHeight = pMaxHeight;
        location = pLocation;
        velocity = pVelocity;
    }


    public static void SetBufferSize( int pBufferSize ) {
        bufferSize = pBufferSize;
    }


    public void FixedTimeStep() {
        location += velocity * Time.fixedDeltaTime;
    }


    public void AccumulateToHeightField( ref double[] rHeightField ) {
        double quarterWaveLength = 0.25 * waveLength;
        int start = ( int )( ( location - quarterWaveLength ) * bufferSize );
        int end = ( int )( ( location + quarterWaveLength ) * bufferSize );

        for ( int i = start; i < end; ++i ) {
            int iNew = i;
            if ( i < 0 ) {
                iNew = -i - 1;
            }
            else if ( i >= ( int )( bufferSize ) ) {
                iNew = 2 * bufferSize - i - 1;
            }

            double distance = Math.Abs( ( i + 0.5 ) / bufferSize - location );
            double height = maxHeight * 0.5 * ( Math.Cos( Math.Min( distance * Math.PI / quarterWaveLength, Math.PI ) ) + 1.0 );
            rHeightField[iNew] += height;
        }
    }
}