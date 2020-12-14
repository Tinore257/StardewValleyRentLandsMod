﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.TerrainFeatures;
using xTile.Layers;
using xTile.Tiles;

namespace FirstStardewValleyMod
{
    public class ModEntry : Mod
    {

        private List<GameLocationStruct> gameLocationStruct = new List<GameLocationStruct>();

        private List<GameLocation> locationsList = new List<GameLocation>();


        private XmlSerializer locationSerializer;

        private SerializableDictionary<GameLocation, TerrainFeaturePairList> TerrainFeatureLocation = new SerializableDictionary<GameLocation, TerrainFeaturePairList>();


        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
            // the game clears locations when loading the save, so do it after the save loads
            helper.Events.GameLoop.SaveLoaded += this.OnSaveLoaded;
            helper.Events.GameLoop.Saving += this.OnSaving;
            helper.Events.GameLoop.DayStarted += this.OnDayStarted;
            helper.Events.World.TerrainFeatureListChanged += this.OnTerrainFeatureListChanged;
            locationSerializer = new XmlSerializer(typeof(FirstStardewValleyMod.GameLocationStruct));
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // print button presses to the console window
            //this.Monitor.Log($"{Game1.player.Name} pressed {e.Button}.", LogLevel.Debug);

            if (e.Button.Equals(SButton.OemPlus))
            {
                this.Monitor.Log($"{Game1.player.Name} ist ein Cheater!", LogLevel.Warn);
                //  Game1.player.Money += 100;
                Game1.playSound("purchase");
                Game1.addHUDMessage(new HUDMessage("+100", 4));
                //Game1.player.addedSpeed +=100;
                //Game1.dayOfMonth++;
            }
            else if (e.Button.Equals(SButton.OemMinus))
            {
                this.Monitor.Log($"{Game1.player.Name} ist ein dummer Cheater!", LogLevel.Warn);
                // Game1.player.Money -= 100;
                Game1.playSound("purchase");
                Game1.addHUDMessage(new HUDMessage("-100", 3));
                //Game1.dayOfMonth--;
                //Game1.player.addedSpeed-= 100;
            }

        }


        private void OnSaveLoaded(object sender, SaveLoadedEventArgs args)
        {

            this.Monitor.Log($"{Game1.player.Name} ES WIRD EINE SAVE GELADEN!!", LogLevel.Warn);
            // get the internal asset key for the map file
            string mapAssetKey = this.Helper.Content.GetActualAssetKey("assets/myModMap2.tmx", ContentSource.ModFolder);
            // add the location
            GameLocation location = new GameLocation(mapAssetKey, "YourLocationName") { IsOutdoors = true, IsFarm = false };


            string tilesheetPath = this.Helper.Content.GetActualAssetKey("assets/spring_outdoorsTileSheet.png", ContentSource.ModFolder);

            TileSheet tilesheet = new TileSheet(
                 id: "z_your-custom-spritesheet", // a unique ID for the tilesheet
                map: location.map,
                imageSource: tilesheetPath,
                sheetSize: new xTile.Dimensions.Size(25, 79), // the tile size of your tilesheet image.
                tileSize: new xTile.Dimensions.Size(16, 16) // should always be 16x16 for maps
            );
            location.map.AddTileSheet(tilesheet);
            location.map.LoadTileSheets(Game1.mapDisplayDevice);

            Random random = new Random();
            int[] alternativeGrasses = { 150, 175, 175, 175, 175, 175, 175, 275, 275, 275, 275, 275, 275, 255, 402, 402, 402, 402, 402, 175, 175, 175, 175, 175, 175, 275, 275, 275, 275, 275, 275, 175, 175, 175, 175, 175, 175, 275, 275, 275, 275, 275, 275, 175, 175, 175, 175, 175, 175, 275, 275, 275, 275, 275, 275, 175, 175, 175, 175, 175, 175, 275, 275, 275, 275, 275, 275, };
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    int tileId = alternativeGrasses[random.Next(0, alternativeGrasses.Length - 1)];
                    Layer layer1 = location.map.GetLayer("Back");

                    layer1.Tiles[x, y] = new StaticTile(layer1, tilesheet, BlendMode.Alpha, tileIndex: tileId); // change tile index
                    location.setTileProperty(x, y, "Back", "Diggable", "T");
                }
            }

            Layer layer = location.map.GetLayer("Buildings");
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if ((x == 0) || (y == 0) || (x == 99) || (y == 99))
                    {
                        layer.Tiles[x, y] = new StaticTile(layer, tilesheet, BlendMode.Alpha, tileIndex: 330); // change tile index
                    }
                }
            }

            Game1.locations.Add(location);
        }


        private void OnSaving(object sender, SavingEventArgs args)
        {
            int counter = 0;
            GameLocation choosenLocation = null;//locationsList[0];   
            for (int i = 0; i < Game1.locations.Count; i++)
            {
                if (Game1.locations[i] != null && Game1.locations[i].name.Equals("YourLocationName"))
                {
                    this.Monitor.Log($"{Game1.locations[i].name} es wurde eine Location in Game1.Locations gefunden mit dem Passenden Namen!", LogLevel.Warn);
                    choosenLocation = Game1.locations[i];
                    counter++;
                }
            }

            this.Monitor.Log($"{counter} mal wurde die Location in Locations gefunden!", LogLevel.Warn);

            GameLocationStruct locationStruct = saveDataPrepare(choosenLocation);
            this.Monitor.Log($"{Game1.player.Name} JSON wird gesaved!", LogLevel.Warn);

            string dataString;
            using (StringWriter textWriter = new StringWriter())
            {
                locationSerializer.Serialize(textWriter, locationStruct);
                dataString = textWriter.ToString();
            }
            Helper.Data.WriteSaveData("MeineLocation", dataString);

            for (int i = 0; i < Game1.locations.Count; i++)
            {
                if (Game1.locations[i] != null)
                {
                    //.Monitor.Log($"{Game1.locations[i]} - es wurde eine Location gefunden beim Saven!", LogLevel.Warn);
                }
                if (Game1.locations[i] != null && Game1.locations[i].name.Equals("YourLocationName"))
                {
                    Game1.locations.RemoveAt(i);
                }

            }

        }


        private void OnDayStarted(object sender, DayStartedEventArgs args)
        {

            if (Helper.Data.ReadSaveData<String>("MeineLocation") != null)
            {
                this.Monitor.Log($"{Game1.player.Name} Es wurde eine Save Datei gefunden JSON!", LogLevel.Warn);
                String serializedString = Helper.Data.ReadSaveData<String>("MeineLocation");
                if (serializedString == null)
                    return;


                GameLocationStruct gameLocationStruct;
                using (TextReader reader = new StringReader(serializedString))
                {
                    gameLocationStruct = (GameLocationStruct)locationSerializer.Deserialize(reader);
                }

                if (gameLocationStruct == null)
                    return;

                string mapAssetKey = this.Helper.Content.GetActualAssetKey("assets/myModMap2.tmx", ContentSource.ModFolder);
                GameLocation location = new GameLocation(mapAssetKey, "YourLocationName") { IsOutdoors = true, IsFarm = false };

                load(location, gameLocationStruct);
                Game1.locations.Add(location);

                for (int x = 0; x < 100; x++)
                {
                    for (int y = 0; y < 100; y++)
                    {
                        // int tileId =  Int32.Parse(loeadedMap.GetLayer("Back").Tiles[x, y].Id);
                        int tileId = 175;
                        Layer layer1 = location.map.GetLayer("Back");
                        location.setTileProperty(x, y, "Back", "Diggable", "T");
                    }
                }
                return;

            }

            this.Monitor.Log($"{Game1.player.Name} Es wurde KEINE Save Datei gefunden!", LogLevel.Warn);
        }


        private void OnTerrainFeatureListChanged(object sender, TerrainFeatureListChangedEventArgs args)
        {

            //MUSS NOCH SO UMGESCHRIEBEN WERDEN, DASS AUVCH MEHRER ELEMENTE GESPEICHERT WERDEN!!!!


            if (!args.Location.name.Equals("YourLocationName"))
                return;

            this.Monitor.Log($"{args} TerrainFeatureListChanged!!", LogLevel.Warn);
            for (int i = 0; i < Game1.locations.Count; i++)
            {
                if (Game1.locations[i] != null && Game1.locations[i].name.Equals("YourLocationName") && args.Added.Count() > 0)
                {
                    //Game1.locations[i].terrainFeatures.Add(args.Added.ToArray()[0].Key, args.Added.ToArray()[0].Value);
                    if (!TerrainFeatureLocation.ContainsKey(Game1.locations[i]))
                        TerrainFeatureLocation.Add(Game1.locations[i], new TerrainFeaturePairList());

                    for (int j = 0; j < TerrainFeatureLocation.Count(); j++)
                    {
                        if (TerrainFeatureLocation.Keys != null && TerrainFeatureLocation.Keys.ToArray()[j].name.Equals(Game1.locations[i].name))
                        {
                            TerrainFeatureLocation.Values.ToArray()[j].terrainFeaturePairs.Add( new TerrainFeaturePair(args.Added.ToArray()[0].Key, args.Added.ToArray()[0].Value));
                            
                        }
                    }

                    return;
                }
            }
        }



        private void load(GameLocation gameLocation, GameLocationStruct gameLocationStruct)
        {

            string tilesheetPath = this.Helper.Content.GetActualAssetKey("assets/spring_outdoorsTileSheet.png", ContentSource.ModFolder);
            //gameLocation.map = new Map();
            TileSheet tilesheet = new TileSheet(
                 id: "z_your-custom-spritesheet", // a unique ID for the tilesheet
                map: gameLocation.map,
                imageSource: tilesheetPath,
                sheetSize: new xTile.Dimensions.Size(25, 79), // the tile size of your tilesheet image.
                tileSize: new xTile.Dimensions.Size(16, 16) // should always be 16x16 for maps
            );
            gameLocation.map.AddTileSheet(tilesheet);
            gameLocation.map.LoadTileSheets(Game1.mapDisplayDevice);

            for (int i = 0; i < gameLocationStruct.Tiles.Count; i++)
            {
                Tile currentTile = gameLocationStruct.Tiles[i];
                String currentLayerString = currentTile.LayerName;

                Layer layer1 = gameLocation.map.GetLayer(currentLayerString);
                if (layer1 == null)
                    continue;

                layer1.Tiles[currentTile.X, currentTile.Y] = new StaticTile(layer1, tilesheet, BlendMode.Alpha, tileIndex: currentTile.TileID); // change tile index       

            }

            if (gameLocationStruct.terrainFeatures != null)
            {
                this.Monitor.Log($"{gameLocationStruct.terrainFeatures.Keys.ToList().Count} ist die Anzahl der TerrainFeatures!!", LogLevel.Warn);
                foreach (KeyValuePair<Vector2, TerrainFeature> terrainFeature in gameLocationStruct.terrainFeatures)
                {
                    gameLocation.terrainFeatures.Add(terrainFeature.Key, terrainFeature.Value);
                }
            }


            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    gameLocation.setTileProperty(x, y, "Back", "Diggable", "T");
                }
            }
        }


        private GameLocationStruct saveDataPrepare(GameLocation gameLocation)
        {
            GameLocationStruct gameLocationStruct = new GameLocationStruct();
            gameLocationStruct.terrainFeatures = new SerializableDictionary<Vector2, TerrainFeature>();

            String[] layersName = { "Back", "Buildings", "Paths", "Front", "AlwaysFront" };
            for (int i = 0; i < layersName.Length; i++)
            {
                Layer currentLayer = gameLocation.map.GetLayer(layersName[i]);
                if (currentLayer == null)
                    continue;

                gameLocationStruct.width = currentLayer.LayerWidth < gameLocationStruct.width ? gameLocationStruct.width : currentLayer.LayerWidth;
                gameLocationStruct.height = currentLayer.LayerHeight < gameLocationStruct.height ? gameLocationStruct.height : currentLayer.LayerHeight;
                for (int x = 0; x < currentLayer.LayerWidth; x++)
                {
                    for (int y = 0; y < currentLayer.LayerHeight; y++)
                    {
                        if (currentLayer.Tiles[x, y] != null)
                        {
                            gameLocationStruct.Tiles.Add(new Tile(Tile.TileLayerFormString(layersName[i]), x, y, currentLayer.Tiles[x, y].TileIndex, currentLayer.Tiles[x, y].TileSheet.Id));
                        }
                    }
                }
            }

            for (int j = 0; j < TerrainFeatureLocation.Count(); j++)
            {
                if (TerrainFeatureLocation.Keys != null && TerrainFeatureLocation.Keys.ToArray()[j].name.Equals(gameLocation.name))
                {
                    // TerrainFeatureLocation.Values.ToArray()[j].terrainFeature.Add(args.Added.ToArray()[0].Value);
                    for (int k = 0; k < TerrainFeatureLocation.Values.ToList()[j].terrainFeaturePairs.Count(); k++)
                    {
                        if (!gameLocationStruct.terrainFeatures.ContainsKey(TerrainFeatureLocation.Values.ToList()[j].terrainFeaturePairs[k].vector2))
                            gameLocationStruct.terrainFeatures.Add(TerrainFeatureLocation.Values.ToList()[j].terrainFeaturePairs[k].vector2, TerrainFeatureLocation.Values.ToList()[j].terrainFeaturePairs[k].terrainFeature);
                    }
                }
            }

            this.Monitor.Log($"{gameLocation.terrainFeatures.Keys.ToList().Count} ist die Anzahl der TerrainFeatures beim saven!!", LogLevel.Warn);

            for (int j = 0; j < gameLocation.terrainFeatures.Keys.ToList().Count; j++) //(SerializableDictionary<Vector2, TerrainFeature>.KeyCollection terrainFeature in gameLocation.terrainFeatures)
            {
                gameLocationStruct.terrainFeatures.Add(gameLocation.terrainFeatures.Keys.ToList()[j], gameLocation.terrainFeatures.Values.ToList()[j]);
            }

            return gameLocationStruct;
        }

    }
}