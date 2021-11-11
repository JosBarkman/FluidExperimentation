using UnityEngine;


public class AdaptScale : MonoBehaviour {
    public double Scale {
        get {
            return _scale;
        }
        set {
            _scale = value;
        }
    }


    [SerializeField]
    private KeyCode _downScale = KeyCode.A,
                    _upScale = KeyCode.D;
    
    [SerializeField, Range( 1.01f, 1.1f )]
    private double _speed = 1.01;


    private double _scale;



    void Update() {
        if ( Input.GetKey( _downScale ) ) {
            _scale = _scale / _speed;
        }
        else if ( Input.GetKey( _upScale ) ) {
            _scale = _scale * _speed;
        }
    }
}
