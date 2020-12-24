using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CourierApp_.Forms
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
            this.Date = DateTime.Today;
        }

        public string NameCargo { get; private set; }
        public string Address { get; private set; }
        public bool IsFragile { get; private set; }
        public DateTime Date { get; private set; }
        public double Weight { get; private set; }
        
        private bool WeightValidate()
        {
            if (this.weightField.TextLength == 0 || !double.TryParse(this.weightField.Text, out var weight))
            {
                this.errorProvider.SetError(this.weightField, "Пожалуйста, укажите корректный вес.");
                return false;
            }

            if (weight <= 0 || weight > 31.5)
            {
                this.errorProvider.SetError(this.weightField, "Допустимый вес: по 31,5 кг.");
                return false;
            }

            return true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            var correct = true;

            #region Валидация

            if (this.nameField.TextLength == 0)
            {
                this.errorProvider.SetError(this.nameField, "Пожалуйста, укажите название груза.");
                correct = false;
            }

            correct = WeightValidate() && correct;

            if (this.addressField.TextLength == 0)
            {
                this.errorProvider.SetError(this.addressField, "Пожалуйста, укажите название груза.");
                correct = false;
            }

            if (!correct)
            {
                return;
            }

            #endregion

            this.NameCargo = this.nameField.Text;
            this.Address = this.addressField.Text;
            this.IsFragile = this.isFragileBox.Checked;
            this.Weight = double.Parse(this.weightField.Text);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            this.Date = (DateTime)sender.GetType().GetProperty("Value").GetValue(sender);
        }
    }
}
