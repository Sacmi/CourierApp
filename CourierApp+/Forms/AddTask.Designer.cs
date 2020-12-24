
using System;

namespace CourierApp_.Forms
{
    partial class AddTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DateTimePicker datePicker;
            this.label1 = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.weightField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addressField = new System.Windows.Forms.TextBox();
            this.isFragileBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            datePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // datePicker
            // 
            datePicker.Location = new System.Drawing.Point(12, 277);
            datePicker.MinDate = new System.DateTime(2020, 12, 11, 2, 12, 11, 976);
            datePicker.Name = "datePicker";
            datePicker.Size = new System.Drawing.Size(353, 31);
            datePicker.TabIndex = 7;
            datePicker.Value = new System.DateTime(2020, 12, 11, 2, 12, 11, 976);
            datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название груза";
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(13, 41);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(352, 31);
            this.nameField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Вес (в кг.)";
            // 
            // weightField
            // 
            this.weightField.Location = new System.Drawing.Point(13, 108);
            this.weightField.Name = "weightField";
            this.weightField.Size = new System.Drawing.Size(352, 31);
            this.weightField.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес доставки";
            // 
            // addressField
            // 
            this.addressField.Location = new System.Drawing.Point(13, 175);
            this.addressField.Name = "addressField";
            this.addressField.Size = new System.Drawing.Size(352, 31);
            this.addressField.TabIndex = 5;
            // 
            // isFragileBox
            // 
            this.isFragileBox.AutoSize = true;
            this.isFragileBox.Location = new System.Drawing.Point(13, 213);
            this.isFragileBox.Name = "isFragileBox";
            this.isFragileBox.Size = new System.Drawing.Size(108, 29);
            this.isFragileBox.TabIndex = 6;
            this.isFragileBox.Text = "Хрупкий";
            this.isFragileBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Доставить к";
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(252, 315);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(112, 34);
            this.confirm.TabIndex = 9;
            this.confirm.Text = "Добавить";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 362);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.label4);
            this.Controls.Add(datePicker);
            this.Controls.Add(this.isFragileBox);
            this.Controls.Add(this.addressField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.weightField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTask";
            this.ShowInTaskbar = false;
            this.Text = "AddTask";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox weightField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox addressField;
        private System.Windows.Forms.CheckBox isFragileBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}