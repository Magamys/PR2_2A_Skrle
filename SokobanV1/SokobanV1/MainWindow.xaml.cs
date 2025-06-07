using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SokobanV1
{


    public partial class MainWindow : Window
    {
        private Rectangle player;
        private int GridSize = 0;
        private int playerX = 0;
        private int playerY = 0;
        private List<Box> boxes = new List<Box>();
        private List<Rectangle> boxVisuals = new List<Rectangle>();
        private List<TargetSpot> targetSpots = new List<TargetSpot>(); 
        private List<Obstacle> obstacles = new List<Obstacle>();

        public MainWindow()
        {
            InitializeComponent();
        }

        


        private void DrawBoxes()
        {
            foreach (var box in boxes)
            {
                var boxVisual = new Rectangle
                {
                    Fill = Brushes.SaddleBrown
                };
                boxVisuals.Add(boxVisual);
                Board.Children.Add(boxVisual);
                UpdateBoxVisual(box, boxVisual);
            }
        }

        private void DrawObstacles()
        {
            foreach (Obstacle obs in obstacles)
            {
                Rectangle wall = new Rectangle { Fill = Brushes.Gray };
                Grid.SetColumn(wall, obs.X);
                Grid.SetRow(wall, obs.Y);
                Board.Children.Add(wall);
            }


        }

        private void DrawPlayer()
        {
            player = new Rectangle { Fill = Brushes.Black };
            UpdatePlayerPosition();
            Board.Children.Add(player);
        }

        private void DrawTargetSpots()
        {
            foreach (TargetSpot spot in targetSpots)
            {
                Rectangle target = new Rectangle
                {
                    Fill = Brushes.Green
                };
                Grid.SetColumn(target, spot.X);
                Grid.SetRow(target, spot.Y);
                Board.Children.Add(target);
            }
        }

        private void LoadMapFromFile(string filePath)
        {
            

            string[] lines = File.ReadAllLines(filePath);
            int maxLineLength = 0;

            foreach (string line in lines)
            {
                if (line.Length > maxLineLength)
                {
                    maxLineLength = line.Length;
                }
            }

            int rows = lines.Length;

            GridSize = Math.Max(maxLineLength, rows);

            Board.Children.Clear();
            Board.RowDefinitions.Clear();
            Board.ColumnDefinitions.Clear();
            obstacles.Clear();
            boxes.Clear();
            boxVisuals.Clear();
            targetSpots.Clear();


            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char ch = line[x];

                    switch (ch)
                    {
                        case '#':
                            obstacles.Add(new Obstacle(x, y));
                            break;
                        case '@':
                            playerX = x;
                            playerY = y;
                            break;
                        case '$':
                            boxes.Add(new Box(x, y));
                            break;
                        case '.':
                            targetSpots.Add(new TargetSpot(x, y));
                            break;
                        case '*':
                            boxes.Add(new Box(x, y));
                            targetSpots.Add(new TargetSpot(x, y));
                            break;
                        case '+':
                            playerX = x;
                            playerY = y;
                            targetSpots.Add(new TargetSpot(x, y));
                            break;
                    }
                }
            }

            InitGrid();
            DrawObstacles();
            DrawTargetSpots();
            DrawBoxes();
            DrawPlayer();
        }

        private void InitGrid()
        {          
            for (int i = 0; i < GridSize; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition());
                Board.ColumnDefinitions.Add(new ColumnDefinition());
            }           
        }

        

        private void UpdatePlayerPosition()
        {
            Grid.SetRow(player, playerY);
            Grid.SetColumn(player, playerX);
        }

        private void UpdateBoxVisual(Box box, Rectangle visual)
        {
            Grid.SetColumn(visual, box.X);
            Grid.SetRow(visual, box.Y);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            int x = 0;
            int y = 0;
            Box boxAtTarget = null;

            switch (e.Key)
            {
                case Key.Up:
                    y = -1;
                    break;
                case Key.Down:
                    y = 1;
                    break;
                case Key.Left:
                    x = -1;
                    break;
                case Key.Right:
                    x = 1;
                    break;
                case Key.Escape:
                    GamePanel.Visibility = Visibility.Collapsed;
                    StartPanel.Visibility = Visibility.Visible;
                    return;
                default:
                    return;
            }

            int targetX = playerX + x;
            int targetY = playerY + y;

            if (targetX < 0 || targetX >= GridSize || targetY < 0 || targetY >= GridSize)
                return;

            foreach (Box box in boxes)
            {
                if (box.IsAt(targetX, targetY))
                {
                    boxAtTarget = box;
                    break;
                }
            }

            if (boxAtTarget != null)
            {
                int boxTargetX = boxAtTarget.X + x;
                int boxTargetY = boxAtTarget.Y + y;

                if (boxTargetX < 0 || boxTargetX >= GridSize || boxTargetY < 0 || boxTargetY >= GridSize)
                    return;

                if (IsObstacleAt(boxTargetX, boxTargetY))
                    return;

                foreach (Box box in boxes)
                {
                    if (box.IsAt(boxTargetX, boxTargetY))
                        return;
                }

                boxAtTarget.TryMoveTo(boxTargetX, boxTargetY, obstacles, GridSize);

                Rectangle visual = boxVisuals[boxes.IndexOf(boxAtTarget)];
                UpdateBoxVisual(boxAtTarget, visual);

                if (boxAtTarget.IsOnTarget(targetSpots))
                {
                    visual.Fill = Brushes.Yellow;
                }
                else
                {
                    visual.Fill = Brushes.SaddleBrown;
                }

                playerX = targetX;
                playerY = targetY;
                UpdatePlayerPosition();
            }
            else
            {
                if (!IsObstacleAt(targetX, targetY))
                {
                    playerX = targetX;
                    playerY = targetY;
                    UpdatePlayerPosition();
                }
            }

            CheckWinCondition();
        }

        private bool IsObstacleAt(int x, int y)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.X == x && obstacle.Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private void Lvl_1_Click(object sender, RoutedEventArgs e)
        {
            StartGame("Level-1.txt");
        }

        private void Lvl_2_Click(object sender, RoutedEventArgs e)
        {
            StartGame("Level-2.txt");

        }

        private void Lvl_3_Click(object sender, RoutedEventArgs e)
        {
            StartGame("Level-3.txt");

        }

        private void StartGame(string filePath)
        {
            LoadMapFromFile(filePath);
            StartPanel.Visibility = Visibility.Collapsed;
            GamePanel.Visibility = Visibility.Visible;

        }

        private void RestartGame_click(object sender, RoutedEventArgs e)
        {
            WinPanel.Visibility = Visibility.Collapsed;
            StartPanel.Visibility = Visibility.Visible;
        }

        private void CheckWinCondition()
        {
            foreach (var box in boxes)
            {
                if (!box.IsOnTarget(targetSpots))
                    return;
            }

            GamePanel.Visibility = Visibility.Collapsed;
            WinPanel.Visibility = Visibility.Visible;
        }
    }
}
