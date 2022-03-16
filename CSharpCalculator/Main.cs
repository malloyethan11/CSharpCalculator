using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSharpCalculator
{
    // ============================================================================
    // Name: Main
    // Abstract: Main class, inherits form class. Contains main method and all form-level methods
    // ============================================================================
    public partial class Main : Form
    {
        Calculator Calculator = new Calculator();

        public Main()
        {
            InitializeComponent();
            
            // define event handler for input/output box,
            // sets up only allowing numeric input
            this.InputOutputBox.KeyPress += new KeyPressEventHandler(InputOutput_KeyPress);

        }


        // ------------------------------------------------------------------------
        // Button Click Event Methods
        // ------------------------------------------------------------------------
        #region Button Click Event Methods

        private void Zero_Click(object sender, EventArgs e)
        {
            long inputLength = InputOutputBox.Text.Length;
            string userInput = InputOutputBox.Text;

            if (inputLength > 0)
            {
                if (userInput == string.Empty)
                {
                    InputOutputBox.Text = "0";
                    Calculator.SetUserInput1("0");
                }
                else if (isAllZero(userInput) == true)
                {
                    InputOutputBox.Text = "0";
                }
                else
                {
                    InputOutputBox.Text += "0";
                }
            }
            else
            {
                InputOutputBox.Text += "0";
            }
        }



        private void One_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "1";
            }
            else
            {
                InputOutputBox.Text += "1";
            }
        }



        private void Two_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "2";
            }
            else
            {
                InputOutputBox.Text += "2";
            }
        }



        private void Three_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "3";
            }
            else
            {
                InputOutputBox.Text += "3";
            }
        }



        private void Four_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "4";
            }
            else
            {
                InputOutputBox.Text += "4";
            }
        }



        private void Five_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "5";
            }
            else
            {
                InputOutputBox.Text += "5";
            }
        }



        private void Six_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "6";
            }
            else
            {
                InputOutputBox.Text += "6";
            }
        }



        private void Seven_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "7";
            }
            else
            {
                InputOutputBox.Text += "7";
            }
        }



        private void Eight_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "8";
            }
            else
            {
                InputOutputBox.Text += "8";
            }
        }



        private void Nine_Click(object sender, EventArgs e)
        {
            if (isAllZero(InputOutputBox.Text) == true)
            {
                InputOutputBox.Text = "9";
            }
            else
            {
                InputOutputBox.Text += "9";
            }
        }



        private void PositiveNegative_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {

            }
        }



        private void Dot_Click(object sender, EventArgs e)
        {
            InputOutputBox.Text += ".";
            InputOutputBox.Select(InputOutputBox.Text.Length, 0);
        }



        private void Equals_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                Calculator.SetUserInput2(InputOutputBox.Text);
                char mathOperator = Calculator.GetOperator();
                double result = 0;
                double num1 = 0;
                double num2 = 0;
                string strNum1 = Calculator.GetUserInput1();
                string strNum2 = Calculator.GetUserInput2();

                double.TryParse(strNum1, out num1);
                double.TryParse(strNum2, out num2);

                switch (mathOperator)
                {
                    case '+':
                        result = Calculator.Add(num1, num2);
                        break;
                    case '-':
                        result = Calculator.Subtract(num1, num2);
                        break;
                    case '*':
                        result = Calculator.Multiply(num1, num2);
                        break;
                    case '/':
                        result = Calculator.Divide(num1, num2);
                        break;
                }

                Calculator.SetResult(result);
                DisplayResults(result);
                AddToHistory(strNum1, mathOperator, strNum2, result.ToString());
            }
        }


        private void Plus_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                Calculator.SetUserInput1(InputOutputBox.Text);
                InputOutputBox.Text = string.Empty;
                Calculator.SetOperator('+');
            }
        }



        private void Minus_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                Calculator.SetUserInput1(InputOutputBox.Text);
                InputOutputBox.Text = string.Empty;
                Calculator.SetOperator('-');
            }
        }



        private void Times_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                Calculator.SetUserInput1(InputOutputBox.Text);
                InputOutputBox.Text = string.Empty;
                Calculator.SetOperator('*');
            }
        }



        private void Divide_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                Calculator.SetUserInput1(InputOutputBox.Text);
                InputOutputBox.Text = string.Empty;
                Calculator.SetOperator('/');
            }
        }



        private void Backspace_Click(object sender, EventArgs e)
        {
            int textLength = InputOutputBox.Text.Length;

            if (textLength > 0)
            {
                InputOutputBox.Text = InputOutputBox.Text.Remove(textLength - 1);
            }
        }



        private void SquareRoot_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                double result;
                string num = InputOutputBox.Text;
                string userInput1 = InputOutputBox.Text;
                char mathOperator = '\u221A';
                string userInput2 = "2";

                // are these 5 lines necessary???
                Calculator.SetUserInput1(userInput1);
                Calculator.SetUserInput2(userInput2);
                Calculator.SetOperator(mathOperator);
                result = Calculator.CalculateSquareRoot(num);
                Calculator.SetResult(result);

                InputOutputBox.Text = result.ToString();
                AddToHistory(userInput1, mathOperator, userInput2, result.ToString());

            }
        }



        private void ClearAllInput_Click(object sender, EventArgs e)
        {
            Calculator.ResetAllLengths();
            Calculator.SetOperator('\0');
            Calculator.SetResult(0);
            Calculator.SetUserInput1("\0");
            Calculator.SetUserInput2("\0");
            InputOutputBox.Text = string.Empty;
        }



        private void Squared_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                double result;
                string num = InputOutputBox.Text;
                string userInput1 = InputOutputBox.Text;
                char mathOperator = '^';
                string userInput2 = "2";

                // are these 5 lines necessary???
                Calculator.SetUserInput1(userInput1);
                Calculator.SetUserInput2(userInput2);
                Calculator.SetOperator(mathOperator);
                result = Calculator.CalculateSquare(num);
                Calculator.SetResult(result);

                InputOutputBox.Text = result.ToString();
                AddToHistory(userInput1, mathOperator, userInput2, result.ToString());
            }
        }



        private void ClearEntry_Click(object sender, EventArgs e)
        {
            InputOutputBox.Text = string.Empty;
        }



        private void OneOverX_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {

            }
        }



        // Percent_Click() relies on the following Microsoft DevBlog post: https://devblogs.microsoft.com/oldnewthing/20080110-00/?p=23853
        private void Percent_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {
                char mathOperator = Calculator.GetOperator();
                string userInput1;
                string userInput2;
                userInput1 = Calculator.GetUserInput1();
                userInput2 = Calculator.GetUserInput2();

                if (userInput1 == string.Empty)
                {
                    userInput1 = InputOutputBox.Text;
                    Calculator.SetUserInput1(userInput1);

                    switch (mathOperator)
                    {
                        case '+': case '-':
                            // do stuff
                            break;
                        case '*': case '/':
                            // do stuff
                            break;
                    }
                }
                else if (userInput2 == string.Empty)
                {
                    userInput2 = InputOutputBox.Text;
                    Calculator.SetUserInput2(userInput2);

                    switch (mathOperator)
                    {
                        case '+': case '-':
                            // do stuff
                            break;
                        case '*': case '/':
                            // do stuff
                            break;
                    }
                }
            }
        }



        private void MemoryRecall_Click(object sender, EventArgs e)
        {

        }



        private void MemoryClear_Click(object sender, EventArgs e)
        {

        }



        private void MemoryAdd_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {

            }
        }



        private void MemorySubtract_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {

            }
        }



        private void MemoryStore_Click(object sender, EventArgs e)
        {
            if (IsNumeric(InputOutputBox.Text) == true)
            {

            }
        }



        private void History_Click(object sender, EventArgs e)
        {

        }



        private void HistoryMemory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void Memory_Click(object sender, EventArgs e)
        {

        }



                private void ClearHistory_Click(object sender, EventArgs e)
        {
            if (HistoryMemory.Items.Count == 0)
            {
                MessageBox.Show("History is already empty.");
            }
            else
            {
                HistoryMemory.Items.Clear();
            }
        }

        #endregion



        // ------------------------------------------------------------------------
        // Other Methods
        // ------------------------------------------------------------------------
        #region Other Methods
        private bool isAllZero(string text)
        {
            bool result = false;
            int numberOfZeroes = 0;

            if (text.Length > 0)
            {
                foreach (char num in text)
                {
                    if (num == '0')
                    {
                        numberOfZeroes++;
                    }
                }
            }

            if (numberOfZeroes == text.Length && text == string.Empty)
            {
                result = false;
            }
            else if (numberOfZeroes == text.Length)
            {
                result = true;
            }

            return result;
        }



        private void InputOutput_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 43) // +
            {
                Plus_Click(sender, e);
            }

            if (e.KeyChar == 45) // -
            {
                Minus_Click(sender, e);
            }

            if (e.KeyChar == 42) // *
            {
                Times_Click(sender, e);
            }

            if (e.KeyChar == 47) // /
            {
                Divide_Click(sender, e);
            }

            if (e.KeyChar == 13) // <ENTER>
            {
                Equals_Click(sender, e);
            }

            if (e.KeyChar == 46) // .
            {
                Dot_Click(sender, e);
            }

            // need to manually handle zero keypress so that user can't enter "0000000"
            if (e.KeyChar == 48)
            {
                // use ZeroHandler() instead of Zero_Click() because latter method causes bugs
                ZeroHandler();
            }

            // after all other conditions, limit input to only digits and backspace
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }



        private void ZeroHandler()
        {
            long inputLength = InputOutputBox.Text.Length;
            string userInput = InputOutputBox.Text;

            if (inputLength > 0)
            {
                if (userInput == string.Empty)
                {
                    InputOutputBox.Text = "0";
                    Calculator.SetUserInput1("0");
                }
                else if (isAllZero(userInput) == true)
                {
                    InputOutputBox.Text = "";
                }
            }
        }



        private bool IsNumeric(string text)
        {
            bool results = false;

            if (Regex.IsMatch(text, @"^-*\d+\.?\d*E*\+*\d*$")) 
            {
                results = true;
            }
            else
            {
                MessageBox.Show("Please enter numbers only.");
            }

            return results;
        }



        public void DisplayResults(double result)
        {
            InputOutputBox.Text = result.ToString();
        }



        //private void SetUserInput(string num)
        //{
        //    if (Calculator.GetUserInput1() == string.Empty)
        //    {
        //        Calculator.SetUserInput1(num);
        //    }
        //    else
        //    {
        //        Calculator.SetUserInput2(num);
        //    }
        //}



        private void AddToHistory(string num1, char mathOperator, string num2, string result)
        {
            HistoryMemory.Items.Add(num1 + " " + mathOperator + " " + num2 + " = " + result);
        }
    }
    #endregion


    // ============================================================================
    // Name: Calculator
    // Abstract: Class to hold calculator properties and methods. 
    // ============================================================================
    public class Calculator
    {
        // class properties
        private char m_Operator;
        private double m_Result;
        private string m_MemValue;
        private string m_UserInput1;
        private string m_UserInput2;
        private long m_Length1;
        private long m_Length2;

        // ------------------------------------------------------------------------
        // Getters and Setters
        // ------------------------------------------------------------------------
        public void SetOperator(char symbol)
        {
            m_Operator = symbol;
        }

        public char GetOperator()
        {
            return m_Operator;
        }



        public void SetResult(double num)
        {
            m_Result = num;
        }

        public double GetResult()
        {
            return m_Result;
        }



        public void SetUserInput1(string num)
        {
            m_UserInput1 = num;
        }

        public string GetUserInput1()
        {
            return m_UserInput1;
        }



        public void SetUserInput2(string num)
        {
            m_UserInput2 = num;
        }

        public string GetUserInput2()
        {
            return m_UserInput2;
        }



        public void SetLength(long num, long numOption)
        {
            if (numOption == 1)
            {
                m_Length1 = num;
            }
            else if (numOption == 2)
            {
                m_Length2 = num;
            }
        }

        public long GetLength(long lengthNum)
        {
            long length = 0;

            if (lengthNum == 1)
            {
                length = m_Length1;
            }
            else if (lengthNum == 2)
            {
                length = m_Length2;
            }

            return length;
        }



        public void SetMemValue(string num)
        {
            m_MemValue = num;
        }

        public string GetMemValue()
        {
            return m_MemValue;
        }



        // ------------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------------
        public Calculator()
        {
            m_Operator = '0';
            m_Result = 0;
            m_UserInput1 = "";
            m_UserInput2 = "";
            m_Length1 = m_UserInput1.Length;
            m_Length2 = m_UserInput2.Length;
        }



        // ------------------------------------------------------------------------
        // Other class methods
        // ------------------------------------------------------------------------
        public bool IsNumeric(string text)
        {
            bool results = false;

            if (Regex.IsMatch(text, @"^\d+$"))
            {
                results = true;
            }
            else
            {
                MessageBox.Show("Please enter numbers only.");
            }

            return results;
        }



        public void ResetAllLengths()
        {
            m_Length1 = 0;
            m_Length2 = 0;
        }



        public string RemoveAt(int index, string userInput)
        {
            userInput.Remove(index);
            
            return userInput;
        }



        public double Add(double num1, double num2)
        {
            m_Result = num1 + num2;

            return m_Result;
        }



        public double Subtract(double num1, double num2)
        {
            m_Result = num1 - num2;

            return m_Result;
        }



        public double Multiply(double num1, double num2)
        {
            m_Result = num1 * num2;

            return m_Result;
        }



        public double Divide(double num1, double num2)
        {
            m_Result = num1 / num2;

            return m_Result;
        }



        public void Append(string num, string userInput)
        {
            userInput += num;
        }



        public double CalculateSquare(string num)
        {
            double result = 0;

            Double.TryParse(num, out result);
            result *= result;

            return result;
        }


        

        public double CalculateSquareRoot(string num)
        {
            double result = 0;

            double.TryParse(num, out result);
            result = Math.Sqrt(result);

            return result;
        }
    }
}
