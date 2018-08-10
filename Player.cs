using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x { get; set; }
    public int z { get; set; }
    public bool canAttack = false;

    private void OnMouseDown()
    {
        GameCtrl.cleanAttachablePlayerList();
        GameCtrl.cleanMoveableTileList();
        if (canAttack)
        {
            gameObject.SetActive(false);
            Object.Destroy(this);
            return;
        }
        if (GameCtrl.currentSelectedPlayer == this)
        {
            return;
        }
        GameCtrl.currentSelectedPlayer = this;
        showAttackable();
        showMoveable();
    }
    void showAttackable()
    {
        int maxX = Land.instance.x;
        int maxZ = Land.instance.z;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {

                if (x + i < 0 || x + i > maxX || z + j < 0 || z + j > maxZ || (i == 0 & j == 0))
                {
                    continue;
                }

                RaycastHit hit;

                Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(x + i, 0, z + j));
                Ray ray = Camera.main.ScreenPointToRay(pos);

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject go = hit.collider.gameObject;
                    // Debug.DrawLine(ray.origin, hit.point, Color.red, 3);

                    Player player = hit.collider.GetComponent<Player>();
                    if (player != null)
                    {
                        player.enableAttack();
                    }
                }

            }
        }
    }
    void showMoveable()
    {
        Tile[,] tiles = Land.instance.tiles;
        int maxX = Land.instance.x;
        int maxZ = Land.instance.z;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {

                if (x + i < 0 || x + i > maxX || z + j < 0 || z + j > maxZ)
                {
                    continue;
                }

                Tile tile = tiles[x + i, z + j];
                GameCtrl.moveableTileList.Add(tile);
                tile.enableMove();

            }
        }
    }

    public void disableAttack()
    {
        canAttack = false;
    }
    public void enableAttack()
    {
        canAttack = true;
    }
    public void move()
    {
        Tile tile = GameCtrl.currentSelectedTile;
        iTween.MoveTo(gameObject, new Vector3(tile.x, 0, tile.z), 0.2f);
        this.x = tile.x;
        this.z = tile.z;

        GameCtrl.cleanAttachablePlayerList();
        GameCtrl.cleanMoveableTileList();
        this.showAttackable();
    }


}
