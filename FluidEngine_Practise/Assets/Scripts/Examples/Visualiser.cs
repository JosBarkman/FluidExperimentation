using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


public class Visualiser : MonoBehaviour {
    [SerializeField]
    private Vector2 _startingPoint, _endPoint;

    [SerializeField]
    private int _vertexCount = 80;

    [SerializeField]
    private LineRenderer _lineRenderer = null;


    private Vector2[] _waveFormA,
                      _waveFormB;
    private Wave _a = Wave.zero,
                 _b = Wave.zero;
    private float _length, _height;
    private double[] _heightField;



#if UNITY_EDITOR
    private void OnDrawGizmos() {
        Handles.color = Color.yellow;
        Handles.DrawWireDisc( _startingPoint, Vector3.back, 0.08f );
        Handles.color = Color.red;
        Handles.DrawWireDisc( _endPoint, Vector3.back, 0.08f );
    }
#endif


    public void SetWaves( Wave pA, Wave pB ) {
        _a = pA;
        _b = pB;
    }


    private void Start() {
        _length = Mathf.Abs( _endPoint.x - _startingPoint.x );
        _height = 0.5f * ( _endPoint.y + _startingPoint.y );

        _waveFormA = new Vector2[_vertexCount];
        _waveFormB = new Vector2[_vertexCount];
        _lineRenderer.positionCount = _vertexCount;
        Wave.SetBufferSize( _vertexCount );
    }


    public void Update() {
        Draw();
    }


    private void Draw() {
        _heightField = new double[_vertexCount];
        _a.AccumulateToHeightField( ref _heightField );
        _b.AccumulateToHeightField( ref _heightField );


        Vector3[] accumulatedWave = new Vector3[_vertexCount];
        for( int i = 0; i < _vertexCount; ++i ) {
            accumulatedWave[i] = new Vector3( _startingPoint.x + i / ( float )_vertexCount * _length, _startingPoint.y + ( float )_heightField[i] * _height );
        }

        if ( null != _lineRenderer ) {
            _lineRenderer.SetPositions( accumulatedWave );
        }
    }
}