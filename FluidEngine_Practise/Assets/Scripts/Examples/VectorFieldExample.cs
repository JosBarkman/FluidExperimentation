using System;
using UnityEngine;


public class VectorFieldExample : MonoBehaviour {
    private readonly static VectorField3 _vectorField = new CustomVectorFieldB();

    [SerializeField]
    private Vector3 _startingPoint;

    [SerializeField, Range( 1, 3 )]
    private int _size = 1;

    [SerializeField, Range( 0.011f, 0.25f )]
    private double _scale = 0.2f;

    [SerializeField]
    private double _z = Math.PI / 4.0;


    private Vector3[] _vectors;
    private float _vecLength = 0.175f;
    private double _oldScale;
    private int _oldSize;
    private int _actualSize;



    private void Start() {
        CalculateVectors();
    }


    private void OnValidate() {
        if ( _scale != _oldScale || _size != _oldSize ) {
            _actualSize = GetSize( _size );
            _vecLength = ( float )( 0.00000128173828125 * Mathf.Pow( _actualSize, 2f ) -0.00057421875 * _actualSize + 0.073 );
            CalculateVectors();
            _oldScale = _scale;
            _oldSize = _size;
        }
    }


    private void OnDrawGizmos() {
        if ( null != _vectors && _vectors.Length > 0 ) {
            for ( int i = 0; i < _actualSize; ++i ) {
                for ( int j = 0; j < _actualSize; ++j ) {
                    Vector3 vec = _vectors[j * _actualSize + i];
                    Vector3 start = _startingPoint + new Vector3( i * _vecLength * 1.2f, -j * _vecLength * 1.2f );
                    float magCol = ( vec.magnitude / _vecLength ) * ( 1f + _vecLength ) - _vecLength;

                    Vector3 end = start + vec;
                    Vector3 end2 = Quaternion.AngleAxis( 160, Vector3.forward ) * vec / 3f;
                    Vector3 end3 = Quaternion.AngleAxis( -160, Vector3.forward ) * vec / 3f;

                    Gizmos.color = new Color( magCol, magCol, magCol );
                    Gizmos.DrawLine( start, end );
                    Gizmos.color = new Color( magCol, magCol, magCol ) * 0.8f;
                    Gizmos.DrawLine( end, end + end2 );
                    Gizmos.DrawLine( end, end + end3 );
                }
            }
        }
        else if ( Application.isPlaying ) {
            Debug.LogError( "Vectors still empty." );
        }
    }


    private void CalculateVectors() {
        _vectors = new Vector3[_actualSize * _actualSize];

        for ( int i = 0; i < _actualSize; ++i ) {
            for ( int j = 0; j < _actualSize; ++j ) {
                _vectors[j * _actualSize + i] = GetVector( i, j );
            }
        }
    }


    private Vector3 GetVector( int i, int j ) {
        Vector3 vec = _vectorField.sample( i * _scale, j * _scale, _z ) * _vecLength;
        /*Vector3 vec = new Vector3(
            UnityEngine.Random.Range( -1f, 1f ),
            UnityEngine.Random.Range( -1f, 1f )
        );*/
        return vec;
    }


    private int GetSize( int s ) {
        return 33 * s*s - 35 * s + 66;
    }
}