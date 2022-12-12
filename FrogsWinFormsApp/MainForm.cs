namespace FrogsWinFormsApp
{
    public partial class MainForm : Form
    {
        private int movesAmount = 0;
        private int otherSideFrogsAmount = 0;
        private List<PictureBox> leftFrogs;

        public MainForm()
        {
            InitializeComponent();
            leftFrogs = new List<PictureBox>() { leftPictureBox1, leftPictureBox2, leftPictureBox3, leftPictureBox4 };
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            otherSideFrogsAmount = 0;
            Swap((PictureBox)sender);
        }

        private void Swap(PictureBox clickedPicture)
        {
            if (Math.Abs(clickedPicture.Location.X - emptyPictureBox.Location.X) / emptyPictureBox.Size.Width > 2)
            {
                MessageBox.Show("Так нельзя!");
            }
            else
            {
                var location = clickedPicture.Location;
                clickedPicture.Location = emptyPictureBox.Location;
                emptyPictureBox.Location = location;
                movesAmountLabel.Text = ($"Количество ходов: {movesAmount += 1}").ToString();
                foreach (var pictureBox in leftFrogs)
                {
                    if (pictureBox.Location.X > ClientSize.Width / 2)
                    {
                        otherSideFrogsAmount++;
                    }
                }
            }
            IsWin();
        }

        private void IsWin()
        {
            if (otherSideFrogsAmount == leftFrogs.Count && emptyPictureBox.Location.X == leftFrogs.Count * emptyPictureBox.Width)
            {
                this.Hide();
                new Win(movesAmount).ShowDialog();
            }
        }

        private void rulesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цель игры — расположить лягушек, которые смотрят влево, в левую часть, а остальных - в правую часть за минимальное количество перепрыгиваний.\n\nПрыгать можно на листок, если он находится рядом или через 1 лягушку");
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}