//using System.Collections.Generic;
using UnityEngine;
using Stahle.Utility;

namespace Stahle.GridMaker
{
    public class VisualGridMaker : PersistantSingleton<VisualGridMaker>
    {
        //If you want sprites to be displayed instead of simple colored blocks
        //public List<Sprite> sprites = new List<Sprite>();
        //The prefab Instantiated when the board is created
        public GameObject tile;
        //x dimension of the board
        public int xSize;
        //y dimension of the board
        public int ySize;
        //A 2D array of tiles that make up a board grid
        private GameObject[,] tiles;
        public bool IsShifting { get; set; }
        private int randomInt;

        //public static BoardManager Instance = null;
        #region Singleton
        //private void Awake()
        //{
        //if (Instance == null)
        //{
        //    Instance = this;
        //    Vector2 offset = tile.GetComponentInChildren<SpriteRenderer>().bounds.size;
        //    CreateBoard(offset.x, offset.y);
        //}
        //else if (Instance != this)
        //{
        //    Destroy(gameObject);
        //}
        //DontDestroyOnLoad(gameObject);
        //}
        #endregion

        private void CreateBoard(float xOffset, float yOffset)
        {
            tiles = new GameObject[xSize, ySize];
            float startX = transform.position.x;
            float startY = transform.position.y;

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x),
                        startY + (yOffset * y), 0), tile.transform.rotation);

                    tiles[x, y] = newTile;
                    //Parent all tiles to your BoardManager for organization
                    newTile.transform.parent = transform;


                    //Randomly choose a sprite from the dragged-in ones
                    //Sprite newSprite = sprites[Random.Range(0, blocks.Count)];
                    //Get the spriteRenderer component from the new tile we cloned.
                    SpriteRenderer spriteRenderer = newTile.GetComponentInChildren<SpriteRenderer>();
                    //Set the tile's sprite to the randomly chosen newSprite
                    //spriteRenderer.sprite = newSprite;
                    //Figure a random number between 0-3.
                    randomInt = Random.Range(0, 5);
                    if (randomInt < 4)
                    {
                        //Get the newTiles Block.cs component
                        Block newTilesBlockComponent = newTile.GetComponent<Block>();
                        //Cast the randomInt into its respective enum value and assign it to the newTile's Block component.
                        newTilesBlockComponent.BlockColor = (ColorType)randomInt;
                        //Assign a color based on a switch statement that switches on 0-4 and assigns a predetermined color for that number
                        spriteRenderer.color = ChooseRandomColor(randomInt);
                    }
                    else //blank blocks need to be turned off
                    {
                        Destroy(newTile);
                    }
                }
            }
        }
        private Color32 ChooseRandomColor(int randomNum)
        {
            Color32 newColor;

            switch (randomNum)
            {
                case 0:
                    newColor = new Color32(255, 255, 255, 255);
                    break;
                case 1:
                    newColor = new Color32(176, 38, 50, 255);
                    break;
                case 2:
                    newColor = new Color32(47, 205, 91, 255);
                    break;
                case 3:
                    newColor = new Color32(55, 128, 212, 255);
                    break;
                default:
                    newColor = new Color(255, 255, 255, 255);
                    Debug.Log("That projectile color doesnt exist, setting to White.");
                    break;
            }
            return newColor;
        }
    }
}
//white = 0,
//red = 1,
//green = 2,
//blue = 3,