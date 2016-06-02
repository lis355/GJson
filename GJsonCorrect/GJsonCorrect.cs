﻿using System;
using System.Windows.Forms;
using GJsonTests;

namespace GJsonCorrect
{
	public partial class GJsonCorrectForm : Form
	{
		private const string KTestFile = "test.json";

		private readonly GJsonCorrectFormController _controller;

		public GJsonCorrectForm()
		{
			InitializeComponent();

			_controller = new GJsonCorrectFormController(this);

			SetStatusText(string.Empty);

			InputBox.Text = Tests.ReadFile(KTestFile);
			InputBox.SelectionStart = Math.Max(0, InputBox.Text.Length - 1);
			InputBox.SelectionLength = 0;
		}

		public void SetStatusText(string txt)
		{
			StatusText.Text = txt;
		}

		private void InputBox_TextChanged(object sender, EventArgs e)
		{
			_controller.OnTextChanged();
		}
	}
}
