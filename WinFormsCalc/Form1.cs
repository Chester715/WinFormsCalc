namespace WinFormsCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool CreatingNum = true;
        int CurrentList = -1;
        List<List<char>> Numbers = new List<List<char>>();
        List<char> Operators = new List<char>();

        public void AddDigit(char Digit)
        {
            if (CreatingNum == true)
            {
                Numbers.Add(new List<char>());
                CurrentList++;
                Numbers[CurrentList].Add(Digit);
                CreatingNum = false;
            }
            else
            {
                Numbers[CurrentList].Add(Digit);
            }

        }

        public void AddOperator(char Operator)
        {
            if (CreatingNum == false)
            {
                Operators.Add(Operator);
                CreatingNum = true;

            }
            else
            {
                MessageBox.Show("Cannot Use 2 operators in a row");
            }
        }

        public void Calculate()
        {
            // Iterate through first list of characters to get an integer value
            for (int i = 0; i > Numbers[1].Count; i++)
            {

            }
            // Iterate through 2nd list of characters to get an integer value
            // Preform calculation on 2 integers
        }
        private void button10_Click(object sender, EventArgs e)
        {
            AddDigit('0');
        }



        private void btn1_Click(object sender, EventArgs e)
        {
            AddDigit('1');
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AddDigit('2');
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AddDigit('3');
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AddDigit('4');
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AddDigit('5');
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AddDigit('6');
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AddDigit('7');
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            AddDigit('8');
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AddDigit('9');
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            AddOperator('+');
        }

        private void btnMINUS_Click(object sender, EventArgs e)
        {
            AddOperator('-');
        }

        private void btnMULT_Click(object sender, EventArgs e)
        {
            AddOperator('*');
        }

        private void btnDIV_Click(object sender, EventArgs e)
        {
            AddOperator('/');
        }

        private void btnEXE_Click(object sender, EventArgs e)
        {
            // Calls a subroutine to perform calculation
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {

        }
    }
}
