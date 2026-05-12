using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EletjatekGUI.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        class MyCommand : ICommand
        {
            Action action;

            public MyCommand(Action action)
            {
                this.action = action;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;
            public void Execute(object? parameter) => action();
        }

        public int[] Meretek { get; init; } = Enumerable.Range(5, 16).ToArray();
        public int Rows { get; set; } = 20;
        public int Columns { get; set; } = 20;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand CreateNew { get; init; }
        public ICommand Save { get; init; }
        public MainWindow Context { get; set; }


        #if ELSO_MEGOLDAS
        void SaveTable()
        {
            if (Context.CheckBoxGrid.Rows == 0 || Context.CheckBoxGrid.Columns == 0)
            {
                return;
            }

            using var output = new StreamWriter($"eletjatek_{Context.CheckBoxGrid.Rows}x{Context.CheckBoxGrid.Columns}.txt");

            for (int i = 0; i < Context.CheckBoxGrid.Rows; i++)
            {
                for (int j = 0; j < Context.CheckBoxGrid.Columns; j++)
                {
                    var cb = (Context.CheckBoxGrid.Children[i * Context.CheckBoxGrid.Columns + j] as CheckBox)!;
                    output.Write(cb.IsChecked ?? true ? "1" : "0");
                }
                output.WriteLine();
            }
        }
        
        void CreateNewTable()
        {
            Context.CheckBoxGrid.Children.Clear();
            Context.CheckBoxGrid.Rows = Rows;
            Context.CheckBoxGrid.Columns = Columns;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var cb = new CheckBox();
                    Context.CheckBoxGrid.Children.Add(cb);
                }
            }
        }
        #else
        bool[,] Ertekek = new bool[0, 0];

        void SaveTable()
        {
            if (Context.CheckBoxGrid.Rows == 0 || Context.CheckBoxGrid.Columns == 0)
            {
                return;
            }

            using var output = new StreamWriter($"eletjatek_{Context.CheckBoxGrid.Rows}x{Context.CheckBoxGrid.Columns}.txt");

            for (int i = 0; i < Context.CheckBoxGrid.Rows; i++)
            {
                for (int j = 0; j < Context.CheckBoxGrid.Columns; j++)
                {
                    output.Write(Ertekek[i, j] ? "1" : "0");
                }
                output.WriteLine();
            }
        }

        void CreateNewTable()
        {
            Context.CheckBoxGrid.Children.Clear();
            Context.CheckBoxGrid.Rows = Rows;
            Context.CheckBoxGrid.Columns = Columns;
            Ertekek = new bool[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    var cb = new CheckBox();
                    cb.Tag = new Tuple<int, int>(i, j);
                    cb.Checked += (o, e) =>
                    {
                        var pos = (cb.Tag as Tuple<int, int>);
                        Ertekek[pos.Item1, pos.Item2] = cb.IsChecked ?? true;
                    };
                    Context.CheckBoxGrid.Children.Add(cb);
                }
            }
        }
        #endif

        public MainViewModel()
        {
            this.CreateNew = new MyCommand(CreateNewTable);
            this.Save = new MyCommand(SaveTable);
        }
    }
}
