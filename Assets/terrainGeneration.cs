using UnityEngine;

public class terrainGeneration : MonoBehaviour
{
   public int depth = 20; 
   public int width = 2560;
   public int height = 2560;
   public float scale = 200f;

   Vector3 followTarget;


   void Update(){
       followTarget = GameObject.Find("CruiseFighter").transform.position;
       transform.position = new Vector3(followTarget.x-width/2, transform.position.y, followTarget.z-height/2);

       Terrain terrain = GetComponent<Terrain>();
       terrain.terrainData = GenerateTerrain(terrain.terrainData);
   }

   TerrainData GenerateTerrain(TerrainData terrainData){
       terrainData.heightmapResolution = 500;
       terrainData.size = new Vector3(width, depth, height);
       terrainData.SetHeights(0,0, GenerateHeights());
       return terrainData;
   }

   float[,] GenerateHeights(){
       float[,] heights = new float[width, height];
       for (int x= 0; x<width;x+=10){
           for (int y = 0; y< height; y+=10){
               heights[x,y] = CalculateHeight(x,y,followTarget);
           }
       }
        return heights;
   }
   
    float CalculateHeight(int x, int y, Vector3 targetChange){
        float xCoord = (float)x/width * scale + followTarget.z/1;
        float yCoord = (float)y/height *scale + followTarget.x/1;

        return Mathf.PerlinNoise(xCoord, yCoord); 
    }

}
