using System;
using System.Windows.Forms;

namespace CourierApp_.Forms
{
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
            Date = DateTime.Today;
        }

        public string NameCargo { get; private set; }
        public string Address { get; private set; }
        public bool IsFragile { get; private set; }
        public DateTime Date { get; private set; }
        public double Weight { get; private set; }

        private bool WeightValidate()
        {
            if (weightField.TextLength == 0 || !double.TryParse(weightField.Text, out var weight))
            {
                errorProvider.SetError(weightField, "Пожалуйста, укажите корректный вес.");
                return false;
            }

            if (weight <= 0 || weight > 31.5)
            {
                errorProvider.SetError(weightField, "Допустимый вес: по 31,5 кг.");
                return false;
            }

            return true;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            var correct = true;

            #region Валидация

            if (nameField.TextLength == 0)
            {
                errorProvider.SetError(nameField, "Пожалуйста, укажите название груза.");
                correct = false;
            }

            correct = WeightValidate() && correct;

            if (addressField.TextLength == 0)
            {
                errorProvider.SetError(addressField, "Пожалуйста, укажите название груза.");
                correct = false;
            }

            if (!correct) return;

            #endregion

            NameCargo = nameField.Text;
            Address = addressField.Text;
            IsFragile = isFragileBox.Checked;
            Weight = double.Parse(weightField.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void datePicker_ValueChanged(object sender, EventArgs e)
        {
            Date = (DateTime) sender.GetType().GetProperty("Value").GetValue(sender);
        }
    }
}