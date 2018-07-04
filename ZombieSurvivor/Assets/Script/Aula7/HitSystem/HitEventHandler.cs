using UnityEngine;

public interface HitEventHandler
{
    //Método que recebe o evento de colisão deste sistema de Hit
    void OnAgentHited(WeaponDataObject weapon, GameObject agentHited, Vector3 hitPoint);
}
