using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    // variables publicas
	public Color hoverColor;
	public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    // Un Nodo guarda datos como la Torreta, la blueprint y si esta upgraded
	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Color startColor;

    // Define un objeto BuildManager
	BuildManager buildManager;

	void Start ()
	{
        // Renderiza
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
        // y crea un buildmanager
		buildManager = BuildManager.instance;
    }

	public Vector3 GetBuildPosition () //construye un poco mas arriba del centro
	{
		return transform.position + positionOffset;
	}

	void OnMouseDown ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTurret(buildManager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("No hay suficiente Hidrogeno!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

        // Instancia de nueva torreta
		GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

        // Instancia de FX construccion
		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Debug.Log("Torreta Construida!");
	}

	public void UpgradeTurret () //funciones de mejora
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("No hay suficiente Hidrogeno para subir de nivel!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Destruye la torreta antigua
		Destroy(turret);

		//Construye una nueva
		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;
        //FX de construccion
		GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
        // define upgrade
		isUpgraded = true;

		Debug.Log("Torreta Mejorada!");
	}

	public void SellTurret ()
	{
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(turret);
		turretBlueprint = null;
	}

	void OnMouseEnter ()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneyColor;
		}

	}

	void OnMouseExit ()
	{
		rend.material.color = startColor;
    }

}
