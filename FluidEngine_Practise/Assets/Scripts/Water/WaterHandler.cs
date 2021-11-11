using UnityEngine;


public class WaterHandler : MonoBehaviour {
    [SerializeField]
    Visualiser _visualiser;

    [SerializeField]
    private Vector4 _waveA = new Vector4( 0.8f, 0.5f, 0.0f, 1.0f ),
        _waveB = new Vector4( 1.2f, 0.4f, 1.0f, -0.5f );

    private Wave _a, _b;




    private void Awake() {
        if ( null != _visualiser ) {
            _visualiser.SetWaves( _a, _b );
        }

        _a = new Wave( _waveA.x, _waveA.y, _waveA.z, _waveA.w );
        _b = new Wave( _waveB.x, _waveB.y, _waveB.z, _waveB.w );
    }


    private void FixedUpdate() {
        _a.FixedTimeStep();
        _b.FixedTimeStep();
        Bounce( _a );
        Bounce( _b );

        if ( null != _visualiser ) {
            _visualiser.SetWaves( _a, _b );
        }
    }

    
    private void Bounce( Wave wave ) {
        if ( wave.location > 1.0 ) {
            wave.location = 1.0;
            wave.velocity *= -1.0;
        }
        else if ( wave.location < 0.0 ) {
            wave.location = 0.0;
            wave.velocity *= -1.0;
        }
    }
}