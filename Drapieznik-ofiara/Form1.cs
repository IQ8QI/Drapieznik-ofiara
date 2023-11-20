using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Drapieznik_ofiara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }
        /*
         * Simulation values
         */
        private const int gridSize = 400;
        private const int cellSize = 3;
        private const int delayMs = 500;
        /*
         * Simulation values end
         */

        /*
         * Animal behavior values
         */
        private const float random_death_chance = 0.2f;
        private const float random_prey_reproduce_chance = 0.1f;
        private const float random_predator_reproduce_chance = 0.5f;
        private const float bonus_death_chance_if_hungry = -0.4f;
        private const float bonus_death_chance_if_fed = -0.9f;
        private const int max_prey_in_9x9 = 5;

        private double predator_success_rate = 0.5f;
        private double prey_success_rate = 0.5f;
        /*
         * Animal behavior end
         */

        private Random random = new Random();
        private bool isRunning = false;
        private CellType[,] grid;

        private void InitializeGrid()
        {
            grid = new CellType[gridSize, gridSize];

            // Initialize grid with predators and prey
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    switch (random.Next(3))
                    {
                        case 0:
                            grid[i, j] = CellType.Predator;
                            break;
                        case 1:
                            grid[i, j] = CellType.Prey;
                            break;
                        case 2:
                            grid[i, j] = CellType.Empty;
                            break;

                    }
                }
            }

            DrawGrid();
        }

        private void DrawGrid()
        {
            // Clear the PictureBox
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        Rectangle rect = new Rectangle(i * cellSize, j * cellSize, cellSize, cellSize);
                        if (grid[i, j] == CellType.Predator)
                        {
                            g.FillRectangle(Brushes.Red, rect);
                        }
                        else if (grid[i, j] == CellType.Empty)
                        {
                            g.FillRectangle(Brushes.Yellow, rect);
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Green, rect);
                        }
                    }
                }
            }
        }

        private async void StartSimulation()
        {
            isRunning = true;
            while (isRunning)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (grid[i, j] == CellType.Predator)
                        {
                            PredatorBehavior(i, j);
                        }
                        else if (grid[i, j] == CellType.Prey)
                        {
                            PreyBehavior(i, j);
                        }
                    }
                }

                DrawGrid();
                await Task.Delay(delayMs);
            }
        }

        private void PreyBehavior(int x, int y)
        {
            if(!PreyLackFood(x, y))
            {
                AnimalWander(x, y, CellType.Prey);
                AnimalReproduce(x, y, CellType.Prey);
                AnimalDie(x, y, 0);
            }
        }

        private bool PreyLackFood(int x, int y)
        {
            List<Point> nearbyPrey = FindNearby(x, y, CellType.Prey);
            if (nearbyPrey.Count > max_prey_in_9x9)
            {
                grid[x, y] = CellType.Empty;
                return true;
            }
            return false;
        }

        private void PredatorBehavior(int x, int y)
        {
            if(FindNearby(x, y, CellType.Prey).Count == 0)
            {
                AnimalWander(x, y, CellType.Predator);
            }
            if(PredatorHunt(x, y))
            {
                AnimalReproduce(x, y, CellType.Predator);
                AnimalDie(x, y, bonus_death_chance_if_fed);
            } else
            {
                AnimalDie(x, y, bonus_death_chance_if_hungry);
            }
            
        }

        private void AnimalWander(int x, int y, CellType animalType)
        {
            List<Point> nearbyEmpty = FindNearby(x, y, CellType.Empty);
            if (nearbyEmpty.Count > 0)
            {
                int index = random.Next(nearbyEmpty.Count);
                Point emptyLocation = nearbyEmpty[index];
                grid[emptyLocation.X, emptyLocation.Y] = animalType;
                grid[x, y] = CellType.Empty;
            }
        }

        private bool PredatorHunt(int x, int y)
        {
            double huntChance = predator_success_rate;
            if (random.NextDouble() < huntChance)
            {
                List<Point> nearbyPrey = FindNearby(x, y, CellType.Prey);
                List<Point> nearbyPredator = FindNearby(x, y, CellType.Predator);

                if (nearbyPrey.Count > 0)
                {
                    int index = random.Next(nearbyPrey.Count);
                    Point preyLocation = nearbyPrey[index];
                    grid[preyLocation.X, preyLocation.Y] = CellType.Empty;
                    return true;
                }
                else if(nearbyPredator.Count > 0)
                {
                    int index = random.Next(nearbyPredator.Count);
                    Point predatorLocation = nearbyPredator[index];
                    grid[predatorLocation.X, predatorLocation.Y] = CellType.Empty;
                    return true;
                }
            }
            return false;
        }

        private void AnimalReproduce(int x, int y, CellType animalType)
        {
            float random_reproduce_chance = 0; ;
            if (animalType == CellType.Predator)
            {
                random_reproduce_chance = random_predator_reproduce_chance;
            } else if(animalType == CellType.Prey)
            {
                random_reproduce_chance = random_prey_reproduce_chance;
            }
            List<Point> nearbyEmpty = FindNearby(x, y, CellType.Empty);
            if(nearbyEmpty.Count > 0)
            {
                if (random.NextDouble() < random_reproduce_chance)
                {
                    int index = random.Next(nearbyEmpty.Count);
                    Point emptyLocation = nearbyEmpty[index];
                    grid[emptyLocation.X, emptyLocation.Y] = animalType;
                }
            }
        }

        private void AnimalDie(int x, int y, double extra_chance)
        {
            if(random.NextDouble() < random_death_chance + (random_death_chance * extra_chance))
            {
                grid[x, y] = CellType.Empty;
            }
        }

        private List<Point> FindNearby(int x, int y, CellType type)
        {
            List<Point> nearby = new List<Point>();

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    if (newX >= 0 && newX < gridSize && newY >= 0 && newY < gridSize)
                    {
                        if (grid[newX, newY] == type)
                        {
                            nearby.Add(new Point(newX, newY));
                        }
                    }
                }
            }

            return nearby;
        }

        private void ResetSimulation()
        {
            isRunning = false;
            InitializeGrid();
        }

        private void StopSimulation()
        {
            isRunning = false;
        }

        private void start_simulation_click(object sender, EventArgs e)
        {
            StartSimulation();
        }

        private void stop_simulation_click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void exit_program_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reset_simulation_click(object sender, EventArgs e)
        {
            ResetSimulation();
        }

        private void predator_success_changed(object sender, EventArgs e)
        {
            predator_success_rate = (float)hunt_success.Value / hunt_success.Maximum * 0.05;
        }

        private void prey_success_changed(object sender, EventArgs e)
        {
            prey_success_rate = (float)prey_success.Value / prey_success.Maximum * 0.05;
        }
    }

    enum CellType
    {
        Empty,
        Predator,
        Prey
    }
}