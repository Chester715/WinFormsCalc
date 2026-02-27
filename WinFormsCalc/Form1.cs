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
        List<int> CalcNums = new List<int>();

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
            var result = 
                new MultiplyOperator(new Number(5.0), new MultiplyOperator(new Number(4.0), new NegativeOperator(new Number(3.0))))
                .GetResult();

            // Iterate through first list of characters to get an integer value
            

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


public abstract class ExpressionNode
{
    public abstract double GetResult();
}

public class Number : ExpressionNode
{

    public double Value { get; }

    public Number(double value)
    {
        Value = value;
    }

    public override double GetResult()
    {
        return Value;
    }
}

public abstract class Operator : ExpressionNode
{
    public string OperatorSymbol { get; set; }

    protected Operator(string operatorSymbol)
    {
        OperatorSymbol = operatorSymbol;
    }

}

public abstract class UnaryOperator : Operator
{

    public ExpressionNode RHS { get; }

    public UnaryOperator(string operatorSymbol, ExpressionNode rhs) : base(operatorSymbol)
    {
        RHS = rhs;
    }
}

public abstract class BinaryOperator : Operator
{

    public ExpressionNode LHS { get; }
    public ExpressionNode RHS { get;  }

    public BinaryOperator(string operatorSymbol, ExpressionNode lhs, ExpressionNode rhs) : base(operatorSymbol)
    {
        LHS =lhs;
        RHS = rhs;
    }
}

public class MultiplyOperator : BinaryOperator
{
    public MultiplyOperator(ExpressionNode lhs, ExpressionNode rhs) : base("*", lhs, rhs)
    {
        
    }

    public override double GetResult()
    {
        return LHS.GetResult() * RHS.GetResult();
    }

}
public class AdditionOperator : BinaryOperator
{
    public AdditionOperator(ExpressionNode lhs, ExpressionNode rhs) : base("+", lhs, rhs)
    {
        
    }

    public override double GetResult()
    {
        return LHS.GetResult() + RHS.GetResult();
    }

}

public class DivisionOperator : BinaryOperator
{
    public DivisionOperator(ExpressionNode lhs, ExpressionNode rhs) : base("/", lhs, rhs)
    {
        
    }

    public override double GetResult()
    {
        return RHS.GetResult() / LHS.GetResult();
    }

}

public class SubtractionOperator : BinaryOperator
{
    public SubtractionOperator(ExpressionNode lhs, ExpressionNode rhs) : base("-", lhs, rhs)
    {
        
    }

    public override double GetResult()
    {
        return RHS.GetResult() - LHS.GetResult();
    }

}



public class NegativeOperator : UnaryOperator
{
    public NegativeOperator(Number rhs) : base("-", rhs)
    {
    }

    public override double GetResult()
    {
        return -RHS.GetResult();
    }

}
