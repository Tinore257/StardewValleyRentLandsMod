using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Network;
using StardewValley.TerrainFeatures;
using xTile;
using xTile.Layers;
using xTile.Tiles;


namespace FirstStardewValleyMod
{
    class ModMapData
    {

        public Map map;
        public float waterPosition;
        public bool forceLoadPathLayerLights;
        public bool forceViewportPlayerFollow;
        public bool waterTileFlip;
        public int waterAnimationTimer;
        public int waterAnimationIndex;
        public TemporaryAnimatedSprite fishSplashAnimation;
        public Event currentEvent;
        public List<TemporaryAnimatedSprite> temporarySprites;
        public int numberOfSpawnedObjectsOnMap;
        public List<Action> postFarmEventOvernightActions;
        public TemporaryAnimatedSprite orePanAnimation;
        public List<TerrainFeature> _activeTerrainFeatures;
        public Vector2 lastTouchActionLocation;
        public string lastQuestionKey;
        public bool[,] waterTiles;
        public StardewValley.Object actionObjectForQuestionDialogue;
        public bool IsGreenhouse { get; set; }
        public string Name { get; }
      //  public Map Map { get; set; }
        public float LightLevel { get; set; }
        public bool IsOutdoors { get; set; }
        public bool IsFarm { get; set; }


        public static ModMapData createSaveData(GameLocation location)
        {
            return new ModMapData(location);
        }

        public ModMapData() { }

        public ModMapData(GameLocation location)
        {
            this.map = location.map;
            this.waterPosition = location.waterPosition;
            this.forceLoadPathLayerLights = location.forceLoadPathLayerLights;
            this.forceViewportPlayerFollow = location.forceViewportPlayerFollow;
            this.waterTileFlip = location.waterTileFlip;
            this.waterAnimationTimer = location.waterAnimationTimer;
            this.waterAnimationIndex= location.waterAnimationIndex;
            this.fishSplashAnimation = location.fishSplashAnimation;
            this.currentEvent = location.currentEvent;
            this.temporarySprites = location.temporarySprites;
            this.numberOfSpawnedObjectsOnMap = location.numberOfSpawnedObjectsOnMap;
            this.postFarmEventOvernightActions = location.postFarmEventOvernightActions;
            this.orePanAnimation = location.orePanAnimation;
            this._activeTerrainFeatures = location._activeTerrainFeatures;
            this.lastTouchActionLocation = location.lastTouchActionLocation;
            this.lastQuestionKey = location.lastQuestionKey;
            this.waterTiles = location.waterTiles;
            this.actionObjectForQuestionDialogue = location.actionObjectForQuestionDialogue;
    }

        public GameLocation toGameLocation()
        {
            GameLocation newLocation = new GameLocation();
            if(this.map != null)
            newLocation.map = this.map;
            if (this.waterPosition != null)
                newLocation.waterPosition = this.waterPosition;
            if (this.forceLoadPathLayerLights != null)
                newLocation.forceLoadPathLayerLights = this.forceLoadPathLayerLights;
            if (this.forceViewportPlayerFollow != null)
                newLocation.forceViewportPlayerFollow = this.forceViewportPlayerFollow;
            if (this.waterTileFlip != null)
                newLocation.waterTileFlip = this.waterTileFlip;
            if (this.waterAnimationTimer != null)
                newLocation.waterAnimationTimer = this.waterAnimationTimer;
            if (this.waterAnimationIndex != null)
                newLocation.waterAnimationIndex = this.waterAnimationIndex;
            if (this.fishSplashAnimation != null)
                newLocation.fishSplashAnimation = this.fishSplashAnimation;
            if (this.currentEvent != null)
                newLocation.currentEvent = this.currentEvent;
            if (this.temporarySprites != null)
                newLocation.temporarySprites = this.temporarySprites;
            if (this.numberOfSpawnedObjectsOnMap != null)
                newLocation.numberOfSpawnedObjectsOnMap = this.numberOfSpawnedObjectsOnMap;
            if (this.postFarmEventOvernightActions != null)
                newLocation.postFarmEventOvernightActions = this.postFarmEventOvernightActions;
            if (this.orePanAnimation != null)
                newLocation.orePanAnimation = this.orePanAnimation;
            if (this._activeTerrainFeatures != null)
                newLocation._activeTerrainFeatures = this._activeTerrainFeatures;
            if (this.lastTouchActionLocation != null)
                newLocation.lastTouchActionLocation = this.lastTouchActionLocation;
            if (this.lastQuestionKey != null)
                newLocation.lastQuestionKey = this.lastQuestionKey;
            if (this.waterTiles != null)
                newLocation.waterTiles = this.waterTiles;
            if (this.actionObjectForQuestionDialogue != null)
                newLocation.actionObjectForQuestionDialogue = this.actionObjectForQuestionDialogue;
            return newLocation;
        }


        public static void CopyGameLocation(GameLocation oldLocation, GameLocation newLocation)
        {
            //GameLocation newLocation = new GameLocation();
            newLocation.map = oldLocation.map;
            newLocation.waterPosition = oldLocation.waterPosition;
            newLocation.forceLoadPathLayerLights = oldLocation.forceLoadPathLayerLights;
            newLocation.forceViewportPlayerFollow = oldLocation.forceViewportPlayerFollow;
            newLocation.waterTileFlip = oldLocation.waterTileFlip;
            newLocation.waterAnimationTimer = oldLocation.waterAnimationTimer;
            newLocation.waterAnimationIndex = oldLocation.waterAnimationIndex;
            newLocation.fishSplashAnimation = oldLocation.fishSplashAnimation;
            newLocation.currentEvent = oldLocation.currentEvent;
            newLocation.temporarySprites = oldLocation.temporarySprites;
            newLocation.numberOfSpawnedObjectsOnMap = oldLocation.numberOfSpawnedObjectsOnMap;
            newLocation.postFarmEventOvernightActions = oldLocation.postFarmEventOvernightActions;
            newLocation.orePanAnimation = oldLocation.orePanAnimation;
            newLocation._activeTerrainFeatures = oldLocation._activeTerrainFeatures;
            newLocation.lastTouchActionLocation = oldLocation.lastTouchActionLocation;
            newLocation.lastQuestionKey = oldLocation.lastQuestionKey;
            newLocation.waterTiles = oldLocation.waterTiles;
            newLocation.actionObjectForQuestionDialogue = oldLocation.actionObjectForQuestionDialogue;
        }

    }

}
