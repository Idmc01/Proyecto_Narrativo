using UnityEngine.Tilemaps;
using UnityEngine;

public class CambiarTilePuerta : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase puertaCerrada;
    public TileBase puertaAbierta;

    private bool abierta = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3Int tilePosJugador = tilemap.WorldToCell(transform.position);

            // Revisar las 4 posiciones alrededor del jugador
            Vector3Int[] direcciones = {
                Vector3Int.right,
                Vector3Int.left,
                Vector3Int.up,
                Vector3Int.down
            };

            foreach (var dir in direcciones)
            {
                Vector3Int posPuerta = tilePosJugador + dir;
                TileBase tileActual = tilemap.GetTile(posPuerta);

                if (tileActual == puertaCerrada || tileActual == puertaAbierta)
                {
                    tilemap.SetTile(posPuerta, abierta ? puertaCerrada : puertaAbierta);
                    abierta = !abierta;
                    break;
                }
            }
        }
    }
}
