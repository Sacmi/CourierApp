namespace CourierApp_.Forms
{
    partial class Tasks
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.addCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCargo = new System.Windows.Forms.ToolStripMenuItem();
            this.clearList = new System.Windows.Forms.ToolStripMenuItem();
            this.CargosViewer = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFragile = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveList = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUnused = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargosViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.FileName = "cargos.json";
            this.openFileDialog.Filter = "JSON | *.json";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusInfo});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Location = new System.Drawing.Point(0, 848);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1400, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusInfo
            // 
            this.statusInfo.Name = "statusInfo";
            this.statusInfo.Size = new System.Drawing.Size(0, 15);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openCustom,
            this.saveList,
            this.addCargo,
            this.deleteCargo,
            this.clearList,
            this.deleteUnused});
            this.menuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1400, 35);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // openCustom
            // 
            this.openCustom.Name = "openCustom";
            this.openCustom.Size = new System.Drawing.Size(98, 29);
            this.openCustom.Text = "Открыть";
            // 
            // addCargo
            // 
            this.addCargo.Name = "addCargo";
            this.addCargo.Size = new System.Drawing.Size(106, 29);
            this.addCargo.Text = "Добавить";
            // 
            // deleteCargo
            // 
            this.deleteCargo.Name = "deleteCargo";
            this.deleteCargo.Size = new System.Drawing.Size(92, 29);
            this.deleteCargo.Text = "Удалить";
            // 
            // clearList
            // 
            this.clearList.Name = "clearList";
            this.clearList.Size = new System.Drawing.Size(103, 29);
            this.clearList.Text = "Очистить";
            // 
            // CargosViewer
            // 
            this.CargosViewer.AllowUserToAddRows = false;
            this.CargosViewer.AllowUserToDeleteRows = false;
            this.CargosViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CargosViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CargosViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Title,
            this.Price,
            this.Weight,
            this.Destination,
            this.IsFragile,
            this.Status,
            this.Time});
            this.CargosViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CargosViewer.Location = new System.Drawing.Point(0, 35);
            this.CargosViewer.Margin = new System.Windows.Forms.Padding(4);
            this.CargosViewer.Name = "CargosViewer";
            this.CargosViewer.RowHeadersWidth = 62;
            this.CargosViewer.Size = new System.Drawing.Size(1400, 813);
            this.CargosViewer.TabIndex = 3;
            this.CargosViewer.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CargosViewer_CellValidating);
            this.CargosViewer.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CargosViewer_CellValueChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.ToolTipText = "Уникальный идентификатор заказа";
            // 
            // Title
            // 
            this.Title.HeaderText = "Название";
            this.Title.MinimumWidth = 8;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.ToolTipText = "Название груза";
            // 
            // Price
            // 
            this.Price.HeaderText = "Стоимость (руб.)";
            this.Price.MinimumWidth = 8;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.ToolTipText = "Стоимость доставки груза. Расчитывается автоматически";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Вес (кг.)";
            this.Weight.MinimumWidth = 8;
            this.Weight.Name = "Weight";
            this.Weight.ToolTipText = "Вес груза. Больше 5 кг. груз считается посылкой. Максимум 31,5 кг.";
            this.Weight.ReadOnly = true;
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Адрес доставки";
            this.Destination.MinimumWidth = 8;
            this.Destination.Name = "Destination";
            this.Destination.ToolTipText = "Куда необходимо доставить груз";
            // 
            // IsFragile
            // 
            this.IsFragile.HeaderText = "Хрупкий";
            this.IsFragile.MinimumWidth = 8;
            this.IsFragile.Name = "IsFragile";
            this.IsFragile.ReadOnly = true;
            this.IsFragile.ToolTipText = "Нужно ли проявлять особую осторожность при перевозке груза";
            // 
            // Status
            // 
            this.Status.HeaderText = "Статус";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ToolTipText = "Статус заказа";
            // 
            // Time
            // 
            this.Time.HeaderText = "Дедлайн";
            this.Time.MinimumWidth = 8;
            this.Time.Name = "Time";
            this.Time.ToolTipText = "До какого числа необходимо доставить заказ";
            // 
            // saveList
            // 
            this.saveList.Name = "saveList";
            this.saveList.Size = new System.Drawing.Size(114, 29);
            this.saveList.Text = "Сохранить";
            // 
            // deleteUnused
            // 
            this.deleteUnused.Name = "deleteUnused";
            this.deleteUnused.Size = new System.Drawing.Size(167, 29);
            this.deleteUnused.Text = "Оптимизировать";
            // 
            // Tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1400, 870);
            this.Controls.Add(this.CargosViewer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Tasks";
            this.Text = "Tasks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Tasks_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CargosViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFragile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewComboBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;

        private System.Windows.Forms.DataGridView CargosViewer;

        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusInfo;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem openCustom;
        private System.Windows.Forms.ToolStripMenuItem clearList;
        private System.Windows.Forms.ToolStripMenuItem addCargo;
        private System.Windows.Forms.ToolStripMenuItem deleteCargo;
        private System.Windows.Forms.ToolStripMenuItem saveList;
        private System.Windows.Forms.ToolStripMenuItem deleteUnused;
    }
}