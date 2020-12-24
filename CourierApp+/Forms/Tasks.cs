using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CourierApp_.Tasks;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CourierApp_.Forms
{
    public partial class Tasks : Form
    {
        private readonly List<SimpleCargo> _cargos = new List<SimpleCargo>();
        private const string DefaultName = "cargos.json";
        private string CurrentName { get; set; }
        private int _counter = 0;
        private const int ActionsToAutosave = 5;
        private bool _disableAutoSave = true;

        public Tasks()
        {
            InitializeComponent();
            Status.Items.AddRange("В ожидании", "Выполняется", "Доставлено");
            clearList.Click += OnClearCargos;
            deleteCargo.Click += OnDeleteCargo;
            addCargo.Click += OnAddCargo;
            openCustom.Click += OnOpenCustom;
            deleteUnused.Click += OnDeleteUnused;
            saveList.Click += OnSave;
            Closing += OnCloseForm;
            saveList.ShortcutKeys = Keys.Control | Keys.S;
            openCustom.ShortcutKeys = Keys.Control | Keys.O;
            clearList.ShortcutKeys = Keys.Control | Keys.N;
            addCargo.ShortcutKeys = Keys.Control | Keys.P;
            deleteCargo.ShortcutKeys = Keys.Control | Keys.K;
            
            CurrentName = DefaultName;
        }

        private void LoadCargos(string path = null)
        {
            _disableAutoSave = true;
            _counter = 0;
            path ??= CurrentName;
            Text = $"АРМ курьера - [{CurrentName}]";
            
            if (!File.Exists(path))
            {
                MessageBox.Show("Не найден список грузов. Создан новый.", "Информация");
                _cargos.Clear();
                SaveCargos();
                return;
            }

            List<CargoDoc> tempList;

            try
            {
                using var fs = new FileStream(path, FileMode.Open);
                var jsonBytes = new byte[fs.Length];
                fs.Read(jsonBytes);
                tempList = JsonSerializer.Deserialize<List<CargoDoc>>(jsonBytes);
            }
            catch (JsonException)
            {
                MessageBox.Show("Файл со списком грузов поврежден. Удалите его или восстановите.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            foreach (var cargo in tempList)
            {

                try
                {
                    CreateCargo(cargo.Name, cargo.Destination, cargo.Weight, cargo.IsFragile, cargo.Time, cargo.ID, cargo.Status);
                }
                catch (Exception)
                {
                    MessageBox.Show($@"Найден некорректный груз - ""{cargo.Name}"", ID: {cargo.ID}. Он будет пропущен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }

            statusInfo.Text = $"Загружено доставок - {_cargos.Count}";
            _disableAutoSave = false;
        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            LoadCargos(CurrentName);
        }

        private void OnCloseForm(object sender, EventArgs e)
        {
            if (_counter == 0) return;

            var dialogResult =
                MessageBox.Show("Сохранить таблицу перед выходом?", "АРМ курьера", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes) SaveCargos();
        }
        
        private void CargosViewer_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (CargosViewer.Rows[e.RowIndex].IsNewRow) return;

            var value = CargosViewer[e.ColumnIndex, e.RowIndex].Value.ToString();

            switch (CargosViewer.Columns[e.ColumnIndex].Name)
            {
                case "Destination":
                    _cargos[e.RowIndex].Destination = value;
                    break;
                case "Status":
                    _cargos[e.RowIndex].Status = GetStatusFromString(value);
                    // нельзя изменить данные выполненого заказа 
                    if (_cargos[e.RowIndex].Status == StatusType.Completed) CargosViewer.Rows[e.RowIndex].ReadOnly = true;
                    break;
                case "Time":
                    _cargos[e.RowIndex].Time = DateTime.Parse(value);
                    break;
            }
            AutoSave();
        }

        private void CargosViewer_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (CargosViewer.Rows[e.RowIndex].IsNewRow) return;
            CargosViewer.Rows[e.RowIndex].ErrorText = "";

            switch (CargosViewer.Columns[e.ColumnIndex].Name)
            {
                case "Weight":
                    if (!double.TryParse(e.FormattedValue.ToString(), out var testDouble) || testDouble < 0)
                    {
                        e.Cancel = true;
                        CargosViewer.Rows[e.RowIndex].ErrorText = "Вес должен быть дробным неотрицательным числом.\nТак же вес записывается через запятую.";
                    }

                    if (testDouble > 31.5)
                    {
                        e.Cancel = true;
                        CargosViewer.Rows[e.RowIndex].ErrorText = "Максимальный вес доступный для транспортировки - 31,5 кг.";
                    }
                    break;
                case "Time":
                    if (!DateTime.TryParse(e.FormattedValue.ToString(), out var testData))
                    {
                        e.Cancel = true;
                        CargosViewer.Rows[e.RowIndex].ErrorText = "Некорректно задана дата!";
                    }

                    if (testData < DateTime.Today)
                    {
                        e.Cancel = true;
                        CargosViewer.Rows[e.RowIndex].ErrorText = "Вы не можете доставить груз в прошлом";
                    }
                    break;
            }
        }

        private void OnClearCargos(object sender, EventArgs e)
        {
            _cargos.Clear();
            CargosViewer.Rows.Clear();
            
            AutoSave();
            statusInfo.Text = $"Таблица с доставками очищена!";
        }

        private void OnDeleteCargo(object sender, EventArgs e)
        {
            if (CargosViewer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выделена строка, удалять нечего!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var count = CargosViewer.SelectedRows.Count;

            foreach (DataGridViewRow row in CargosViewer.SelectedRows)
            {
                var index = row.Index;
                _cargos.RemoveAt(index);
                CargosViewer.Rows.Remove(row);
            }
            
            SaveCargos();
            statusInfo.Text = $"Удалено доставок - {count}";
            AutoSave();
        }

        private void OnDeleteUnused(object sender, EventArgs e)
        {
            _disableAutoSave = true;

            var counter = 0;
            
            foreach (DataGridViewRow row in CargosViewer.Rows)
            {
                if (_cargos[row.Index].Status != StatusType.Completed) continue;
                _cargos.RemoveAt(row.Index);
                CargosViewer.Rows.Remove(row);
                counter++;
            }

            _cargos.Where(cargo => cargo.IsFragile);

            _disableAutoSave = false;
            if (counter != 0)
            {
                statusInfo.Text = $"Удалено ненужных элементов - {counter}.";
                AutoSave();
            }
            else { statusInfo.Text = "Не найдено ненужных элементов."; }
        }

        private void OnSave(object sender, EventArgs e)
        {
            _counter = 0;
            SaveCargos();
            Text = $"АРМ курьера - [{CurrentName}]";
        }
        
        private void SaveCargos(string path = null)
        {
            path ??= CurrentName;
            
            using var fs = new FileStream(path, FileMode.Create);
            var jsonWriter = new Utf8JsonWriter(fs);
            JsonSerializer.Serialize(jsonWriter, _cargos);
            
            statusInfo.Text = $"Последнее сохраненние в {DateTime.Now.ToShortTimeString()}";
        }

        private void CreateCargo(string name, string address, double weight, bool isFragile, DateTime date, int id = -1, StatusType status = StatusType.Waiting)
        {
            if (id == -1) id = _cargos.Count == 0 ? 1 : _cargos.Last().ID + 1;

            if (weight < 5)
                _cargos.Add(new SmallCargo(name, id, isFragile, weight) { Destination = address, Status = status, Time = date});
            else
                _cargos.Add(new BulkyCargo(name, id, isFragile, weight) { Destination = address, Status = status, Time = date});

            var index = CargosViewer.Rows.Add();
            CargosViewer["ID", index].Value = _cargos.Last().ID;
            CargosViewer["Title", index].Value = _cargos.Last().Name;
            CargosViewer["Price", index].Value = _cargos.Last().Price;
            CargosViewer["Weight", index].Value = _cargos.Last().Weight;
            CargosViewer["Destination", index].Value = _cargos.Last().Destination;
            CargosViewer["IsFragile", index].Value = _cargos.Last().IsFragile;
            CargosViewer["Status", index].Value = GetStatusString(_cargos.Last().Status);
            CargosViewer["Time", index].Value = _cargos.Last().Time.ToShortDateString();
        }

        private static string GetStatusString(StatusType statusType)
        {
            return statusType switch
            {
                StatusType.Waiting => "В ожидании",
                StatusType.Completed => "Доставлено",
                StatusType.Processing => "Выполняется",
                _ => throw new ArgumentOutOfRangeException(nameof(statusType), statusType, "Нет такого статуса.")
            };
        }

        private static StatusType GetStatusFromString(string statusString)
        {
            return statusString switch
            {
                "В ожидании" => StatusType.Waiting,
                "Выполняется" => StatusType.Processing,
                "Доставлено" => StatusType.Completed,
                _ => throw new ArgumentOutOfRangeException(nameof(statusString), statusString, "Нет такого статуса.")
            };
        }

        private void OnAddCargo(object sender, EventArgs e)
        {
            using var addTask = new AddTask();
            var dialogResult = addTask.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            _disableAutoSave = true;
            CreateCargo(addTask.NameCargo, addTask.Address, addTask.Weight, addTask.IsFragile, addTask.Date);
            statusInfo.Text = $"Всего доставок - {_cargos.Count}";
            _disableAutoSave = false;
            AutoSave();
        }

        private void OnOpenCustom(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK) return;

            CurrentName = openFileDialog.FileName;
            _disableAutoSave = true;
            _cargos.Clear();
            CargosViewer.Rows.Clear();
            LoadCargos();
            _disableAutoSave = false;
        }

        private void AutoSave()
        {
            if (_disableAutoSave) return;
            _counter++;
            if (_counter / ActionsToAutosave != 1)
            {
                Text = $"*АРМ курьера - [{CurrentName}]";
                return;
            }
            _counter = 0;
            SaveCargos();
            Text = $"АРМ курьера - [{CurrentName}]";
        }
    }
}
