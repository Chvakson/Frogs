namespace FrogsWinFormsApp
{
    public partial class Win : Form
    {
        public Win(int movesAmount)
        {
            InitializeComponent();
            if (movesAmount == 24)
            {
                resultLabel.Text = $"Вы одержали победу за {movesAmount} ходов! Это минимальное количество ходов";
            }
            else 
            {
                resultLabel.Text = $"Вы одержали победу за {movesAmount} ходов! Минимальное количество ходов = 24\nПопробуйте еще раз!";
            }
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Close();
            new MainForm().Show();  
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
