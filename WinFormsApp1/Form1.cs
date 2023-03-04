namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        static decimal num1 = 0;
        static decimal num2 = 0;
        static char op = ' ';
        static string lbltxt = "";
        static bool ksr = false;
        static bool num1ornum2 = false;
        static bool menfi = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            char d = ' ';
            Button? click = (sender as Button);
            if (click != null)d = Convert.ToChar(click.Text);
            if ((d == '-' && num1==0))
            {
                menfi = true;
                label1.Text = d.ToString();
            }
            else if ((d < 58 && d > 47))
            {
                lbltxt += d;
                if (!num1ornum2)
                {
                    num1 = Convert.ToDecimal(lbltxt);
                    if (menfi) num1 = (-num1);
                    label1.Text = num1.ToString();
                }
                else
                {
                    num2 = Convert.ToDecimal(lbltxt);
                    label1.Text = num2.ToString();
                }
            }
            else if (d == '.' && !ksr)
            {
                lbltxt = num1ornum2 ? num2.ToString() : num1.ToString();
                lbltxt += d;
                label1.Text = lbltxt;
                if (!num1ornum2) num1 = Convert.ToDecimal(lbltxt);
                else num2 = Convert.ToDecimal(lbltxt);
                ksr = true;
            }
            else if (d == '-' || d == '/' || d == '*' || d == '+')
            {
                label1.Text = d.ToString();
                num1ornum2 = true;
                ksr = false;
                lbltxt = "";
                op = d;
                menfi = true;
            }
            else if (d == 61)
            {
                switch (op)
                {
                    case '-': label1.Text = (num1 -= num2).ToString(); break;
                    case '+': label1.Text = (num1 += num2).ToString(); break;
                    case '*': label1.Text = (num1 *= num2).ToString(); break;
                    case '/': label1.Text = num2 == decimal.Zero ? "Cannot Zero" : (num1 /= num2).ToString(); break;
                    default:
                        break;
                }
                op = ' ';
                num2 = 0;
                lbltxt = "";
                ksr = false;
            }
            else if (d == 'C')
            {
                op = ' ';
                num1 = 0;
                num2 = 0;
                lbltxt = "";
                ksr = false;
                num1ornum2 = false;
                menfi = false;
                label1.Text = num1.ToString();
            }
            else label1.Text = lbltxt;
        }
    }
}