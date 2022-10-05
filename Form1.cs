namespace Binary_Quiz
{
    public partial class Form1 : Form
    {
        private int[] binaryValues = {1, 2, 4, 8, 16, 32, 64, 128, 256};
        private Random random = new Random();
        private List<ComboBox> comboBoxes = new List<ComboBox>();
        private int total;
        private int questionNumber;

        private Label lblTotal = new Label();
        private Label question = new Label();
        private Label header = new Label();

        public Form1()
        {
            InitializeComponent();
            LoadGame();
        }

        private void LoadGame() 
        {
            Array.Reverse(binaryValues);
            questionNumber = 12;

            this.BackColor = Color.FromArgb(64, 64, 64);
            this.Size = new Size(600, 383);

            header.Text = "Binary Quiz"  + Environment.NewLine + "By Me";
            header.AutoSize = false;
            header.Width = this.ClientSize.Width;
            header.Height = 70;
            header.TextAlign = ContentAlignment.MiddleCenter;
            header.ForeColor = Color.White;
            header.Font = new Font("Arial", 20);

            question.Text = "What is - " + questionNumber + " - in binary?";
            question.AutoSize = false;
            question.Width = this.ClientSize.Width;
            question.Height = 50;
            question.TextAlign = ContentAlignment.MiddleCenter;
            question.ForeColor = Color.LightGreen;
            question.Font = new Font("Arial", 20);
            question.Top = 180;

            lblTotal.Text = "Total: " + total;
            lblTotal.AutoSize = false;
            lblTotal.Width = this.ClientSize.Width;
            lblTotal.Height = 50;
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            lblTotal.ForeColor = Color.White;
            lblTotal.Font = new Font("Arial", 20);
            lblTotal.Top = 230;

            this.Controls.Add(header);
            this.Controls.Add(question);
            this.Controls.Add(lblTotal);

            int x = 30;
            int y = 120;

            for (int i = 0; i < 9; i++)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Width = 50;
                comboBox.Items.Add("0");
                comboBox.Items.Add("1");
                comboBox.SelectedIndex = 0;
                comboBox.Font = new Font("Arial", 16);
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Tag = binaryValues[i].ToString();
                comboBox.Left = x;
                comboBox.Top = y;
                comboBox.FlatStyle = FlatStyle.Flat;

                comboBox.SelectionChangeCommitted += BoxSelectionChangeCommitted;

                comboBoxes.Add(comboBox);

                Label lblVal = new Label();
                lblVal.Text = binaryValues[i].ToString();
                lblVal.Font = new Font("Arial", 16);
                lblVal.Location = new Point(x, y - 32);
                lblVal.AutoSize = false;
                lblVal.Width = 50;
                lblVal.Height = 30;

                Color c = Color.FromArgb(random.Next(200, 255), random.Next(150, 255), random.Next(150, 255));
                lblVal.BackColor = c;
                lblVal.ForeColor = Color.Black;
                lblVal.TextAlign = ContentAlignment.MiddleCenter;
                comboBox.BackColor = c;

                this.Controls.Add(comboBox);
                this.Controls.Add(lblVal);

                x += 60;
            }
        }

        private void ResetGame()
        {
            foreach (ComboBox combo in comboBoxes)
            {
                combo.SelectedIndex = 0;
            }
        }

        private void BoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            string? binaryCode = null;
            total = 0;

            foreach (ComboBox combo in comboBoxes)
            {
                if (combo.SelectedIndex == 1)
                {
                    int i = Convert.ToInt32(combo.Tag);
                    total += i;
                }

                binaryCode += combo.Text;
            }

            lblTotal.Text = "Total: " + total + " In binary: " + binaryCode;

            if (total == questionNumber)
            {
                MessageBox.Show("Correct! Well done, Now try another");
                questionNumber = random.Next(1, 510);

                question.Text = "What is - " + questionNumber + " - in binary?";
                total = 0;
                binaryCode = null;
                ResetGame();
                lblTotal.Text = "Total: " + total + " In binary: " + binaryCode;
            }
        }
    }
}