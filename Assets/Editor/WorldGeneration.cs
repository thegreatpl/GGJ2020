﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    static List<Replace> Replaces = new List<Replace>()
    {
        //dead tree. 
        new Replace()
        {
            corrupt = "Apple Trees_0_0", fix = "Apple Trees_288_256"
        },
        new Replace()
        {
            corrupt = "Apple Trees_32_0", fix = "Apple Trees_320_256"
        },
        new Replace()
        {
            corrupt = "Apple Trees_64_0", fix = "Apple Trees_352_256"
        },
        new Replace()
        {
            corrupt = "Apple Trees_0_32", fix = "Apple Trees_288_288"
        },
        new Replace()
        {
            corrupt = "Apple Trees_32_32", fix = "Apple Trees_320_288"
        },
        new Replace()
        {
            corrupt = "Apple Trees_64_32", fix = "Apple Trees_352_288"
        },
        new Replace()
        {
            corrupt = "Apple Trees_0_64", fix = "Apple Trees_288_320"
        },
        new Replace()
        {
            corrupt = "Apple Trees_32_64", fix = "Apple Trees_320_320"
        },
        new Replace()
        {
            corrupt = "Apple Trees_64_64", fix = "Apple Trees_352_320"
        },
        new Replace()
        {
            corrupt = "Apple Trees_0_96", fix = "Apple Trees_288_352"
        },
        new Replace()
        {
            corrupt = "Apple Trees_32_96", fix = "Apple Trees_320_352"
        },
        new Replace()
        {
            corrupt = "Apple Trees_64_96", fix = "Apple Trees_352_352"
        },


        new Replace()
        {
            corrupt =  "Assorted Terrain 2_128_608", fix = "Assorted Terrain 2_32_416"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_128_544", fix = "Assorted Terrain 2_0_352"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_96_544", fix = "Assorted Terrain 2_32_352"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_160_544", fix = "Assorted Terrain 2_64_352"
        },
        //water
        new Replace()
        { corrupt = "Assorted Terrain 2_512_224", fix = "Assorted Terrain 2_608_608" }, 
        new Replace()
        { corrupt = "Assorted Terrain 2_480_160", fix = "Assorted Terrain 2_576_544" }, 
        new Replace()
        { corrupt = "Assorted Terrain 2_512_160", fix = "Assorted Terrain 2_608_544" },
        new Replace()
        { corrupt = "Assorted Terrain 2_544_160", fix = "Assorted Terrain 2_640_544" },
        //wateredges
        new Replace()
        {
            corrupt = "Assorted Terrain 2_160_640", fix = "Assorted Terrain 2_64_448"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_160_608", fix = "Assorted Terrain 2_64_416"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_160_576", fix = "Assorted Terrain 2_64_384"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_128_576", fix = "Assorted Terrain 2_32_384"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_96_576", fix = "Assorted Terrain 2_0_384"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_96_608", fix = "Assorted Terrain 2_0_416"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_96_640", fix = "Assorted Terrain 2_0_448"
        }, 
        new Replace()
        {
            corrupt = "Assorted Terrain 2_128_640", fix = "Assorted Terrain 2_32_448"
        }

    };


    static List<List<TileData>> tileobjects = new List<List<TileData>>()
    {
        new List<TileData>()
        {
            //dead tree. 
            new TileData()
            {
                Layer = "Walls", Postion = new Vector3Int(0, 0, 0), TileName = "Apple Trees_32_0"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(-1, 0, 0), TileName = "Apple Trees_0_0"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(1, 0, 0), TileName = "Apple Trees_64_0"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(0, 1, 0), TileName = "Apple Trees_32_32"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(-1, 1, 0), TileName = "Apple Trees_0_32"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(1, 1, 0), TileName = "Apple Trees_64_32"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(0, 2, 0), TileName = "Apple Trees_32_64"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(-1, 2, 0), TileName = "Apple Trees_0_64"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(1, 2, 0), TileName = "Apple Trees_64_64"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(0, 3, 0), TileName = "Apple Trees_32_96"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(-1, 3, 0), TileName = "Apple Trees_0_96"
            },
            new TileData()
            {
                Layer = "Foreground", Postion = new Vector3Int(1, 3, 0), TileName = "Apple Trees_64_96"
            },


        }
    };


    static List<string> terrain = new List<string>()
    {
        "Assorted Terrain 2_128_608",
        "Assorted Terrain 2_128_544",
        "Assorted Terrain 2_96_544",
        "Assorted Terrain 2_160_544"
    };


    [MenuItem("MapCreation/RandomMap")]
    static void GenerateMap()
    {

        var map = SceneAsset.FindObjectOfType<MapLoader>();
        map.ClearMap(); 
        var tileman = SceneAsset.FindObjectOfType<TileManager>();
        int size = 100;
        for (int xdx = -size; xdx < size; xdx++)
        {
            for (int ydx = -size; ydx < size; ydx++)
            {
                map.BackGround.SetTile(new Vector3Int(xdx, ydx, 0), tileman.GetTile(terrain.RandomElement()));
            }
        }

        //for (int idx = 0; idx < 30; idx++)
        //{
        //    var element = tileobjects.RandomElement(); 

        //    var basepos = new Vector3Int(Random.Range(-size, size), Random.Range(-size, size), 0); 
        //    foreach(var t in element)
        //    {
        //        switch(t.Layer)
        //        {
        //            case "Background":
        //                map.BackGround.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
        //                break;
        //            case "Foreground":
        //                map.Foreground.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
        //                break;
        //            case "Walls":
        //                map.Walls.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
        //                break;
        //        }
        //    }
        //}


    }

    [MenuItem("MapCreation/GenerateTrees")]
    static void CreateTrees()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        var tileman = SceneAsset.FindObjectOfType<TileManager>();

        var locations = map.Walls.GetAllTileData().Where(x => x.TileName == "Apple Trees_32_0"); 

        foreach(var pos in locations)
        {
            AddTileObj(pos.Postion, tileobjects[0], map); 
        }
    }


    static void AddTileObj(Vector3Int basepos, List<TileData> tileData, MapLoader map)
    {
        var tileman = SceneAsset.FindObjectOfType<TileManager>();

        foreach (var t in tileData)
        {
            switch (t.Layer)
            {
                case "Background":
                    map.BackGround.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
                    break;
                case "Foreground":
                    map.Foreground.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
                    break;
                case "Walls":
                    map.Walls.SetTile(basepos + t.Postion, tileman.GetTile(t.TileName));
                    break;
            }
        }
    }


[MenuItem("MapCreation/VaryWater")]
    static void VaryWater()
    {
        var map = SceneAsset.FindObjectOfType<MapLoader>();
        var tileman = SceneAsset.FindObjectOfType<TileManager>();

        var locations = map.Walls.GetAllTileData().Where(x => x.TileName == "Assorted Terrain 2_512_224");

        List<string> otherwater = new List<string>()
        {
            "Assorted Terrain 2_512_224",
            "Assorted Terrain 2_480_160",
            "Assorted Terrain 2_512_160", 
            "Assorted Terrain 2_544_160"
        };

        foreach(var pos in locations)
        {
            map.Walls.SetTile(pos.Postion, tileman.GetTile(otherwater.RandomElement()));
        }

    }

    [MenuItem("MapCreation/CreateEntities")]
    static void CreateEntities()
    {
        List<Vector3Int> locations = new List<Vector3Int>();
        var map = SceneAsset.FindObjectOfType<MapLoader>();

        var walls = map.Walls.GetAllTileData().Select(x => x.Postion);
        var background = map.BackGround.GetAllTileData().Select(x => x.Postion); 
        for (int idx = 0; idx < Random.Range(10, 15); idx++)
        {
            var rand = background.RandomElement(); 
            if (walls.Contains(rand))
            {
                idx--;
                continue; 
            }
                
            var position = background.Where(x => new RectInt(rand.x - 10, rand.y - 10, 20, 20).Contains(new Vector2Int(x.x, x.y)));

            for (int jdx = 0; jdx < Random.Range(1, 5); jdx++)
            {
                var pos = position.RandomElement();
                if (walls.Contains(pos))
                {
                    jdx--;
                    continue;
                }
                locations.Add(pos);
            }
        }
    }
}

class Replace
{
    public string corrupt; 

    public string fix; 
}