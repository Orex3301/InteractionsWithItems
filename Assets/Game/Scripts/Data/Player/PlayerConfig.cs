using UnityEngine;

namespace Data.Player
{
	[CreateAssetMenu(menuName ="Config/PlayerConfig", fileName ="New Player Config")]
	public class PlayerConfig : ScriptableObject
	{
		[field: SerializeField] public float MovingSpeed { get; private set; }
		[field: SerializeField] public float RotationSpeed { get; private set; }
		[field: SerializeField] public float JumpForce { get; private set; }
		[field: SerializeField] public float LookXLimit { get; private set; }
		[field: SerializeField] public float CameraShakeSpeed { get; private set; }
		[field: SerializeField] public float CameraShakeHeight { get; private set; }
		[field: SerializeField] public Vector3 StartPosition { get; private set; }
	}
}