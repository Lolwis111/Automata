using AutomataGUI.Model;
using System;
using System.Windows.Forms;

namespace AutomataGUI.View
{
    public partial class SimulateWindow : Form
    {
        private StateMachine _stateMachine;

        public SimulateWindow(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;

            InitializeComponent();
        }

        private void Simulate_Load(object sender, EventArgs e)
        {
            labelResult.MaximumSize = new System.Drawing.Size(Size.Width - 50, 0);
        }

        private void ButtonSimulate_Click(object sender, EventArgs e)
        {
            string word = textBoxWord.Text;

            try
            {
                bool result = _stateMachine.Evaluate(word);

                labelResult.ForeColor = System.Drawing.Color.Black;
                labelResult.Text = "Result: ";

                if (result)
                {
                    labelResult.Text += $"'{word}' was accepted.";
                    labelResult.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelResult.Text += $"'{word}' was not accepted.";
                    labelResult.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch(Exception ex)
            {
                labelResult.Text = $"Exception: {ex.Message}";
                labelResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void SimulateWindow_SizeChanged(object sender, EventArgs e)
        {

            labelResult.MaximumSize = new System.Drawing.Size(Size.Width - 50, 0);
        }
    }
}
