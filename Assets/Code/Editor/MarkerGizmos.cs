using Code.Logic.Spawners;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
	[CustomEditor(typeof(EnemySpawnMarker))]
	public class MarkerGizmos : UnityEditor.Editor
	{
		[DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
		public static void RenderCustomGizmo(EnemySpawnMarker spawner, GizmoType type)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(spawner.transform.position, 0.5f);
		}
	}
}