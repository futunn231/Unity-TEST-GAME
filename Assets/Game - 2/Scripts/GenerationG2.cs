using Generation.Spawner;
using System.Collections.Generic;
using UnityEngine;
namespace Generation
{
    class GenerationG2 : MonoBehaviour
    {
        [SerializeField] GameObject wall;
        [SerializeField] GameObject parent;

        [SerializeField] SpawnerG2 spawn;

        [SerializeField] int Width, Height;

        void Start() => Wall();
        void Wall()
        {
            MazeGeneratorCell[,] maze = GenerateMaze();
            for (int x = 0; x < maze.GetLength(0); x += 4)
                for (int z = 0; z < maze.GetLength(1); z += 4)
                {
                    WallG2 wal = Instantiate(wall).GetComponent<WallG2>();
                    wal.gameObject.transform.parent = parent.transform;
                    wal.gameObject.transform.position = new Vector3(x, 0, z);
                    wal.downWall.SetActive(maze[x, z].WallBottom);
                    wal.leftWall.SetActive(maze[x, z].WallLeft);
                    if (x <= 12 && z <= 12) spawn.AddListPoint(wal.GetList());
                }
            spawn.Play();
        }
        MazeGeneratorCell[,] GenerateMaze()
        {
            MazeGeneratorCell[,] cells = new MazeGeneratorCell[Width, Height];

            for (int x = 0; x < cells.GetLength(0); x += 4)
                for (int z = 0; z < cells.GetLength(1); z += 4)
                    cells[x, z] = new MazeGeneratorCell { X = x, Y = z };
            for (int x = 0; x < cells.GetLength(0); x += 4) cells[x, Height - 4].WallLeft = false;
            for (int y = 0; y < cells.GetLength(1); y += 4) cells[Width - 4, y].WallBottom = false;
            RemoveWallsWithBacktracker(cells);
            return cells;
        }

        void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
        {
            MazeGeneratorCell current = maze[0, 0];
            current.Visited = true;

            Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
            do
            {
                List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

                int x = current.X;
                int y = current.Y;

                if (x > 0 && !maze[x - 4, y].Visited) unvisitedNeighbours.Add(maze[x - 4, y]);
                if (y > 0 && !maze[x, y - 4].Visited) unvisitedNeighbours.Add(maze[x, y - 4]);
                if (x < Width - 8 && !maze[x + 4, y].Visited) unvisitedNeighbours.Add(maze[x + 4, y]);
                if (y < Height - 8 && !maze[x, y + 4].Visited) unvisitedNeighbours.Add(maze[x, y + 4]);

                if (unvisitedNeighbours.Count > 0)
                {
                    MazeGeneratorCell chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];
                    RemoveWall(current, chosen);

                    chosen.Visited = true;
                    stack.Push(chosen);
                    current = chosen;
                }
                else current = stack.Pop();
            } while (stack.Count > 0);
        }
        void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
        {
            if (a.X == b.X)
            {
                if (a.Y > b.Y) a.WallBottom = false;
                else b.WallBottom = false;
            }
            else
            {
                if (a.X > b.X) a.WallLeft = false;
                else b.WallLeft = false;
            }
        }
    }
}
public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
}