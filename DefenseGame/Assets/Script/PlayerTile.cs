using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tiles/PlayerTile")]
public class PlayerTile : Tile
{
    public bool isInstallable;
    public GameObject installedObject;
}
