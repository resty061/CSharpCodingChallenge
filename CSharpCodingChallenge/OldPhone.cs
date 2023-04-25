using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CSharpCodingChallenge
{
	public partial class OldPhone : Form
	{
		System.Timers.Timer timer;
		int count = 0;
		
		private void btnTwo_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "2";
			timer.Start();
		}

		private void btnThree_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "3";
			timer.Start();
		}

		private void Home_FormClosed(object sender, FormClosedEventArgs e)
		{
			timer.Stop();
		}

		private void btnAsterisk_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "*";
			txtOutput.Text = Translate(txtInput.Text);
		}

		private void btnFour_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "4";
			timer.Start();
		}

		private void btnFive_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "5";
			timer.Start();
		}

		private void btnSix_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "6";
			timer.Start();
		}

		private void btnSeven_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "7";
			timer.Start();
		}

		private void btnEight_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "8";
			timer.Start();
		}

		private void btnNine_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "9";
			timer.Start();
		}

		private void btnZero_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "0";
			timer.Start();
		}

		private void btnNumberSign_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "#";
			txtOutput.Text = Translate(txtInput.Text);
		}

		private void Home_Load(object sender, EventArgs e)
		{
			timer = new System.Timers.Timer(1000); // fire every 1 second
			timer.Elapsed += HandleTimerElapsed;
		}
		

		private void HandleTimerElapsed(object sender, ElapsedEventArgs e)
		{
			Invoke(new Action(() =>
			{
				count++;
				if (count == 1)
				{
					txtInput.Text += " ";
					count = 0;
					timer.Stop();
					txtOutput.Text = Translate(txtInput.Text);
				}
			}));
		}

		private void btnOne_Click(object sender, EventArgs e)
		{
			timer.Stop();
			txtInput.Text += "1";
			timer.Start();
		}

		public OldPhone()
		{
			InitializeComponent();
		}

		public string Translate(string input)
		{
			if (input.EndsWith("#"))
			{
				return Decode(input);
			}
			else
			{
				return "";
			}
		}

		private string Decode(string input)
		{
			string pattern = @"(0+|1+|2+|3+|4+|5+|6+|7+|8+|9+|\*)";
			Regex regex = new Regex(pattern);
			string[] input_entries = regex.Split(input);

			var entries = input_entries.ToList();
			onTrim(entries);
			onDelete(entries);

			string[] letters = entries.Select(s => s.Replace(s, keypad_dict[s])).ToArray();
			string message = string.Join("", letters);
			return message;
		}
		private void onTrim(List<string> input)
		{
			input.RemoveAll(i => (i == " " || i == "" || i == "#" || i == " #"));
		}

		private void onDelete(List<string> input)
		{
			while (input.Contains("*"))
			{
				int index_first = input.FindIndex(i => i == "*");
				input.RemoveAt(index_first - 1);

				int index_second = input.FindIndex(i => i == "*");
				input.RemoveAt(index_second);
			}
		}

		private Dictionary<string, string> keypad_dict = new Dictionary<string, string>
		{
			["1"] = "&",
			["11"] = "'",
			["111"] = "(",
			["1111"] = "1",
			["0"] = " ",
			["00"] = "0",
			["2"] = "A",
			["22"] = "B",
			["222"] = "C",
			["2222"] = "2",
			["3"] = "D",
			["33"] = "E",
			["333"] = "F",
			["3333"] = "3",
			["4"] = "G",
			["44"] = "H",
			["444"] = "I",
			["4444"] = "4",
			["5"] = "J",
			["55"] = "K",
			["555"] = "L",
			["5555"] = "5",
			["6"] = "M",
			["66"] = "N",
			["666"] = "O",
			["6666"] = "6",
			["7"] = "P",
			["77"] = "Q",
			["777"] = "R",
			["7777"] = "S",
			["77777"] = "7",
			["8"] = "T",
			["88"] = "U",
			["888"] = "V",
			["8888"] = "8",
			["9"] = "W",
			["99"] = "X",
			["999"] = "Y",
			["9999"] = "Z",
			["99999"] = "9"
		};




	}
}
