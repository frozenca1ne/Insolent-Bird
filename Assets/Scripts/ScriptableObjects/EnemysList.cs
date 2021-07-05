using UnityEngine;

[CreateAssetMenu(menuName = "Configs/EnemysList", fileName = "Enemys")]
public class EnemysList : ScriptableObject
{
	[SerializeField] private GameObject noHeadEnemy;
	[SerializeField] private GameObject normalEnemy;
	[SerializeField] private GameObject hornedEnemy;

	public GameObject NoHeadEnemy => noHeadEnemy;
	public GameObject NormalEnemy => normalEnemy;
	public GameObject HornedEnemy => hornedEnemy;
}
