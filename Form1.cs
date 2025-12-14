using System.Media;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // --- Game config ---
        private readonly int cellSize = 20;           // pixels per cell
        private readonly int gridWidth = 20;          // cells across
        private readonly int gridHeight = 20;         // cells down

        // --- Game state ---
        private List<Point> snake;
        private Point food;
        private Direction currentDirection;
        private bool allowDirectionChange = true;     // prevent double-change within one tick
        private Random rnd = new Random();
        private int score;
        private int highScore;                        // current session high score
        private int baseInterval = 200;               // starting timer interval (ms)
        private int minInterval = 50;                 // fastest speed cap

        // Keep selected difficulty fixed
        private string chosenDifficulty = "Easy";

        // Optional: types of food with different scores/effects
        private enum FoodType { Normal, Bonus }
        private FoodType foodType;
        private readonly int bonusSpawnChance = 10; // percent chance new food is bonus

        // Direction
        private enum Direction { Up = 0, Right = 1, Down = 2, Left = 3 }

        public Form1()
        {
            snake = new List<Point>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboSpeed.SelectedIndex = 0;   // Easy
            if (comboSpeed.Items.Count == 0)
            {
                comboSpeed.Items.AddRange(new object[] { "Easy", "Normal", "Hard" });
                comboSpeed.SelectedIndex = 0;
            }

            gamePanel.Paint -= gamePanel_Paint;
            gamePanel.Paint += gamePanel_Paint;

            ResetGameState();
            startPanel.Visible = true;
            gameOverPanel.Visible = false;

            gamePanel.Width = gridWidth * cellSize;
            gamePanel.Height = gridHeight * cellSize;

            int rightWidth = 220;
            this.ClientSize = new Size(gamePanel.Width + rightWidth + 30, gamePanel.Height + 20);
        }

        private void ResetGameState()
        {
            snake = new List<Point>();
            int startX = gridWidth / 2;
            int startY = gridHeight / 2;
            snake.Add(new Point(startX, startY));
            snake.Add(new Point(startX - 1, startY));
            snake.Add(new Point(startX - 2, startY));
            currentDirection = Direction.Right;
            score = 0;
            allowDirectionChange = true;

            btnPause.Enabled = false;
            btnPause.Text = "Pause";
            UpdateScoreLabels();
            gameTimer.Stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!gameTimer.Enabled)
            {
                if (!startPanel.Visible && !gameOverPanel.Visible)
                {
                    gameTimer.Start();
                    btnPause.Text = "Pause";
                }
                return;
            }

            gameTimer.Stop();
            btnPause.Text = "Resume";
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            ResetGameState();
            ChooseStartingSpeed();
            GenerateFood();
            startPanel.Visible = false;
            gameOverPanel.Visible = false;
            btnPause.Enabled = true;
            gameTimer.Start();
        }

        private void ChooseStartingSpeed()
        {
            // Store chosen difficulty so it stays consistent
            chosenDifficulty = comboSpeed.SelectedItem?.ToString() ?? "Easy";

            switch (chosenDifficulty)
            {
                case "Easy": gameTimer.Interval = baseInterval + 80; break;
                case "Hard": gameTimer.Interval = Math.Max(minInterval, baseInterval - 60); break;
                default: gameTimer.Interval = baseInterval; break;
            }
        }

        private void UpdateScoreLabels()
        {
            lblScore.Text = $"Score: {score}";
            lblHighScore.Text = $"High Score: {highScore}";
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
            CheckCollision();
            allowDirectionChange = true;
            gamePanel.Invalidate();
        }

        private void MoveSnake()
        {
            Point head = snake[0];
            Point newHead = head;

            switch (currentDirection)
            {
                case Direction.Up: newHead = new Point(head.X, head.Y - 1); break;
                case Direction.Right: newHead = new Point(head.X + 1, head.Y); break;
                case Direction.Down: newHead = new Point(head.X, head.Y + 1); break;
                case Direction.Left: newHead = new Point(head.X - 1, head.Y); break;
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                int addPoints = (foodType == FoodType.Normal) ? 10 : 30;
                score += addPoints;
                try { SystemSounds.Beep.Play(); } catch { }
                GenerateFood();

                // --- REAL SNAKE SPEED LOGIC ---
                // Determine starting interval based on chosen difficulty
                int startingInterval;
                switch (chosenDifficulty)
                {
                    case "Easy": startingInterval = baseInterval + 80; break;
                    case "Hard": startingInterval = Math.Max(minInterval, baseInterval - 60); break;
                    default: startingInterval = baseInterval; break;
                }

                // Gradually decrease interval as snake eats food (speed increases)
                int decreaseStep = 5; // interval decreases by 5ms per food eaten
                gameTimer.Interval = Math.Max(minInterval, startingInterval - (score / 10) * decreaseStep);
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            if (score > highScore) highScore = score;
            UpdateScoreLabels();
        }

        private void CheckCollision()
        {
            Point head = snake[0];

            if (head.X < 0 || head.X >= gridWidth || head.Y < 0 || head.Y >= gridHeight)
            {
                EndGame("You hit the wall!");
                return;
            }

            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[i] == head)
                {
                    EndGame("You collided with yourself!");
                    return;
                }
            }
        }

        private void EndGame(string reason)
        {
            gameTimer.Stop();
            gameOverPanel.Visible = true;
            lblMessage.Text = $"Game Over\n{reason}\nScore: {score}";
            btnPause.Enabled = false;
            btnPause.Text = "Pause";
            try { SystemSounds.Hand.Play(); } catch { }
            UpdateScoreLabels();
        }

        private void GenerateFood()
        {
            Point p;
            int attempts = 0;
            do
            {
                p = new Point(rnd.Next(0, gridWidth), rnd.Next(0, gridHeight));
                attempts++;
                if (attempts > 10000) break;
            } while (snake.Contains(p));

            food = p;

            int chance = rnd.Next(0, 100);
            foodType = (chance < bonusSpawnChance) ? FoodType.Bonus : FoodType.Normal;
        }

        private void gamePanel_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            using (Pen pen = new Pen(Color.LightGray))
            {
                for (int x = 0; x <= gridWidth; x++)
                    g.DrawLine(pen, x * cellSize, 0, x * cellSize, gridHeight * cellSize);
                for (int y = 0; y <= gridHeight; y++)
                    g.DrawLine(pen, 0, y * cellSize, gridWidth * cellSize, y * cellSize);
            }

            Brush foodBrush = (foodType == FoodType.Normal) ? Brushes.Red : Brushes.Gold;
            g.FillRectangle(foodBrush, food.X * cellSize + 1, food.Y * cellSize + 1, cellSize - 2, cellSize - 2);

            if (snake.Count > 0)
            {
                Point head = snake[0];
                g.FillRectangle(Brushes.DarkGreen, head.X * cellSize + 1, head.Y * cellSize + 1, cellSize - 2, cellSize - 2);

                for (int i = 1; i < snake.Count; i++)
                {
                    var p = snake[i];
                    int green = Math.Max(40, 220 - i * 6);
                    using (Brush b = new SolidBrush(Color.FromArgb(0, green, 0)))
                    {
                        g.FillRectangle(b, p.X * cellSize + 1, p.Y * cellSize + 1, cellSize - 2, cellSize - 2);
                    }
                }
            }
        }

        private void label1_Click(object? sender, EventArgs e) { }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (!allowDirectionChange) return;

            if (e.KeyCode == Keys.Up && currentDirection != Direction.Down)
            {
                currentDirection = Direction.Up;
                allowDirectionChange = false;
            }
            else if (e.KeyCode == Keys.Down && currentDirection != Direction.Up)
            {
                currentDirection = Direction.Down;
                allowDirectionChange = false;
            }
            else if (e.KeyCode == Keys.Left && currentDirection != Direction.Right)
            {
                currentDirection = Direction.Left;
                allowDirectionChange = false;
            }
            else if (e.KeyCode == Keys.Right && currentDirection != Direction.Left)
            {
                currentDirection = Direction.Right;
                allowDirectionChange = false;
            }
        }
    }
}
