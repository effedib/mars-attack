namespace RoverCommandService
{
    public class PlanetMap
    {
        private bool[,] obstacleGrid; // Griglia per gestire gli ostacoli

        public PlanetMap(int width, int height)
        {
            obstacleGrid = new bool[width, height];
            // Inizializza la griglia degli ostacoli, impostando true dove ci sono ostacoli
        }

        public bool CheckObstacle(int x, int y)
        {
            // Controlla se c'è un ostacolo alla posizione (x, y)
            // Restituisce true se c'è un ostacolo, false altrimenti
            return true;
        }
    }
}
