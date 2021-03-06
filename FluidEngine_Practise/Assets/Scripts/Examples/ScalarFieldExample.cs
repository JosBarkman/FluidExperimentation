using System;
using UnityEngine;


[RequireComponent( typeof( AdaptScale ))]
public class ScalarFieldExample : MonoBehaviour {
    private readonly static ScalarField3 _scalarFieldA = new CustomScalarFieldA();


    [SerializeField]
    private MeshRenderer _renderer;

    [SerializeField, Range( 0.014f, 0.07f )]
    private double _scale = 0.05;


    private AdaptScale _adaptScale = null;
    private double _z = Math.PI / 2.0;
    private Material _workingMat = null;
    private double _oldScale = 0.0;



    private void Start() {
        Show();
        _adaptScale = GetComponent<AdaptScale>();
        if ( null != _adaptScale ) {
            _adaptScale.Scale = _scale;
        }
    }


    private void OnValidate() {
        UpdateField();
    }


    private void Update() {
        UpdateField();
    }


    private void UpdateField() {
        if ( null != _adaptScale && _adaptScale.isActiveAndEnabled ) {
            _scale = Math.Max( Math.Min( _adaptScale.Scale, 0.07 ), 0.014 );
            _adaptScale.Scale = _scale;
        }

        if ( _scale != _oldScale ) {
            Show();
            _oldScale = _scale;
        }
    }


    private void Show() {
        if ( null != _renderer ) {
            if ( null != _renderer.sharedMaterial ) {
                _workingMat = new Material( _renderer.sharedMaterial );
                _workingMat.name = "WOW!";
                Texture t;

                if ( null == _workingMat.mainTexture ) {
                    Debug.LogWarning( "No Texture present." );
                    t = new Texture2D( 225, 225, TextureFormat.RGB24, true );
                    SetColours( t, ( float )_scale );
                }
                else if ( _workingMat.mainTexture is Texture2D ) {
                    SetColours( _workingMat.mainTexture, ( float )_scale );
                }
                else {
                    Debug.LogError( "Isn't a Texture2D!" );
                }
            }
            else {
                Debug.LogError( "Material missing." );
            }
        }
        else {
            Debug.LogError( "Renderer missing." );
        }
    }

    private void SetColours( Texture texture, float scale ) {
        Texture2D tex2d = ( Texture2D )texture;
        for ( int i = 0; i < tex2d.width; ++i ) {
            for ( int j = 0; j < tex2d.height; ++j ) {
                double c = _scalarFieldA.sample( i * scale, j * scale, _z );
                float newCol = ( float )( c );
                tex2d.SetPixel( i, j, new Color( newCol * 0.5f + 0.5f, newCol * 0.5f + 0.5f, newCol * 0.5f + 0.5f ) );
            }
        }
        tex2d.Apply();

        _workingMat.mainTexture = tex2d;
        _renderer.material = _workingMat;
    }
}