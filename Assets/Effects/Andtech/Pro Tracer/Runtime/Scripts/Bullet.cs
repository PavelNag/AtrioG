#pragma warning disable 0108

using UnityEngine;

namespace Andtech.ProTracer
{

	public partial class Bullet : TracerObject
	{
		/// <summary>
		/// The maximum allowed length of the bullet.
		/// </summary>
		/// <value>
		/// The maximum allowed length of the bullet.
		/// </value>
		/// <remarks>
		/// The actual length may be less depending on the start and endpoints of the tracer's flight path.
		/// </remarks>
		public float MaxLength
		{
			get => maxLength;
			set => maxLength = value;
		}
		public float MaxWidth
		{
			get => maxWidth;
			set => maxWidth = value;
		}
		public float MaxLife = 2f;
		public Light Light
		{
			get => light;
			set => light = value;
		}
		public override bool IsDone => Tracker.Distance >= Tracker.Length + MaxLength;

		[Header("Bullet Settings")]
		[SerializeField]
		[Tooltip("The maximum allowed length of the bullet.")]
		private float maxLength = 3.0F;
		[SerializeField]
		[Tooltip("The maximum allowed width of the bullet.")]
		private float maxWidth = 0.01F;
		[SerializeField]
		[Tooltip("The bullet light source. (Optional)")]
		private Light light;
		public AudioSource audioSource;

        private void Update()
        {
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 10 * Time.deltaTime);
        }

        private void OnEnable()
		{
			Destroy();
		}

		protected override void Rebuild()
		{
			var length = GetLength();
			var width = Mathf.Min(length, MaxWidth);

			// Upload to transform
			Transform.position = Tracker.Position;
			Transform.rotation = Tracker.Velocity.sqrMagnitude == 0.0F ? Quaternion.identity : Quaternion.LookRotation(Tracker.Velocity);
			Transform.localScale = new Vector3(width, width, length);

			float GetLength()
			{
				var head = Clamp(Tracker.Distance);
				var tail = Clamp(Tracker.Distance - MaxLength);

				return head - tail;
			}
		}
		private void Destroy()
		{

			Destroy(gameObject, MaxLife);
		}

		/// <summary>
		/// Draws the tracer with projectile motion.
		/// </summary>
		/// <param name="origin">The starting position.</param>
		/// <param name="direction">The initial direction of motion.</param>
		/// <param name="speed">How fast should the tracer move?</param>
		/// <param name="timeoutDistance">The maximum distance of the flight path.</param>
		/// <param name="strobeOffset">How much of the tracer should be shown initially? (This eliminates the Wagon-Wheel effect)</param>
		/// <param name="useGravity">Should the tracer obey gravity?</param>
		public virtual void DrawRay(Vector3 origin, Vector3 direction, float speed, float timeoutDistance = float.PositiveInfinity, float strobeOffset = 0.0F, bool useGravity = true) => 
			Preset(Tracker.Kinematic(origin, direction.normalized * speed, useGravity, timeoutDistance, strobeOffset));
	}
}
