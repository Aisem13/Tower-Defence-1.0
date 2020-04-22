using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint ArcherTurret;
    public TurretBlueprint BarrackTurret;
    public TurretBlueprint MageTurret;
    public TurretBlueprint CanonTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectArcherTurret()
    {
        Debug.Log("Archer Turret Select");
        buildManager.SelectTurretToBuild(ArcherTurret);
    }

    public void SelectBarrackTurret()
    {
        Debug.Log("Barrack Turret Select");
        buildManager.SelectTurretToBuild(BarrackTurret);
    }

    public void SelectMageTurret()
    {
        Debug.Log("Mage Turret Select");
        buildManager.SelectTurretToBuild(MageTurret);
    }

    public void SelectCanonTurret()
    {
        Debug.Log("Canon Turret Select");
        buildManager.SelectTurretToBuild(CanonTurret);
    }
}
