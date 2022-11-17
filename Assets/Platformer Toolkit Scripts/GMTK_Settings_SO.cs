using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Created by Jeremy Bond for MI 231 at Michigan State University
/// Built to work with a modified version of the GMTK Platformer Toolkit
/// </summary>
[CreateAssetMenu( fileName = "GMTK_Settings_[GameName]", menuName = "ScriptableObjects/GMTK_Settings", order = 1 )]
public class GMTK_Settings_SO : ScriptableObject
{

    [Header( "Movement Stats" )]
    [SerializeField, Range( 0f, 20f )] [Tooltip( "Maximum movement speed" )] public float maxSpeed = 10f;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to reach max speed" )] public float maxAcceleration = 52f;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to stop after letting go" )] public float maxDecceleration = 52f;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to stop when changing direction" )] public float maxTurnSpeed = 80f;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to reach max speed when in mid-air" )] public float maxAirAcceleration = 0;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to stop in mid-air when no direction is used" )] public float maxAirDeceleration = 0;
    [SerializeField, Range( 0f, 100f )] [Tooltip( "How fast to stop when changing direction when in mid-air" )] public float maxAirTurnSpeed = 80f;
    [SerializeField] [Tooltip( "Friction to apply against movement on stick" )] public float friction = 0;

    [Header( "Movement Options" )]
    [Tooltip( "When false, the charcter will skip acceleration and deceleration and instantly move and stop" )] public bool useAcceleration = true;



    [Header( "Jumping Stats" )]
    [SerializeField, Range( 2f, 5.5f )] [Tooltip( "Maximum jump height" )] public float jumpHeight = 7.3f;

    [SerializeField, Range( 1f, 10f )] [Tooltip( "How long it takes to reach that height before coming back down" )]
    public float jumpDurationFromVideo = 5;
    //If you're using your stats from Platformer Toolkit with this character controller,
    // please note that the number on the Jump Duration handle does not match this stat
    // It is re-scaled, from 0.2f - 1.25f, to 1 - 10.
    [XnTools.ReadOnly]
    [SerializeField, Range( 0.1f, 1.25f )]
    [Tooltip( "For some reason, the GMTK version of the value in the video is different from the one here, so I calculate this from the other value." )]
    public float timeToJumpApex;
    [SerializeField, Range( 0f, 5f )] [Tooltip( "Gravity multiplier to apply when going up" )] public float upwardMovementMultiplier = 1f;
    [SerializeField, Range( 1f, 10f )] [Tooltip( "Gravity multiplier to apply when coming down" )] public float downwardMovementMultiplier = 6.17f;
    [SerializeField, Range( 0, 1 )] [Tooltip( "How many times can you jump in the air?" )] public int maxAirJumps = 0;

    [Header( "Jump Options" )]
    [Tooltip( "Should the character drop when you let go of jump?" )] public bool variablejumpHeight;
    [SerializeField, Range( 1f, 10f )] [Tooltip( "Gravity multiplier when you let go of jump" )] public float jumpCutOff;
    [SerializeField] [Tooltip( "The fastest speed the character can fall" )] public float speedLimit = 26.45f;
    [SerializeField, Range( 0f, 0.3f )] [Tooltip( "How long should coyote time last?" )] public float coyoteTime = 0.15f;
    [SerializeField, Range( 0f, 0.3f )] [Tooltip( "How far from ground should we cache your jump?" )] public float jumpBuffer = 0.15f;





    [Header( "Juice Settings - Squash and Stretch" )]
    [SerializeField] public bool squashAndStretch;
    [SerializeField, Tooltip( "Width Squeeze, Height Squeeze, Duration" )] public Vector3 jumpSquashSettings;
    [SerializeField, Tooltip( "Width Squeeze, Height Squeeze, Duration" )] public Vector3 landSquashSettings;
    [SerializeField, Tooltip( "How powerful should the effect be?" )] public float landSqueezeMultiplier;
    [SerializeField, Tooltip( "How powerful should the effect be?" )] public float jumpSqueezeMultiplier;
    [SerializeField] public float landDrop = 1;

    [Header( "Juice Settings - Tilting" )]

    [SerializeField] public bool leanForward;
    [SerializeField, Tooltip( "How far should the character tilt?" )] public float maxTilt;
    [SerializeField, Tooltip( "How fast should the character tilt?" )] public float tiltSpeed;





    private void OnValidate() {
        timeToJumpApex = scale( 1, 10, 0.2f, 1.25f, jumpDurationFromVideo);
    }

    public float scale( float OldMin, float OldMax, float NewMin, float NewMax, float OldValue ) {
        float OldRange = ( OldMax - OldMin );
        float NewRange = ( NewMax - NewMin );
        float NewValue = ( ( ( OldValue - OldMin ) * NewRange ) / OldRange ) + NewMin;

        return ( NewValue );
    }
}
