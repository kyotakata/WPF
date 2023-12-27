using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace WPF023
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Dto> _dtos = new ObservableCollection<Dto>();
        public MainWindow()
        {
            InitializeComponent();

            var dto1 = new Dto("Name1");
            dto1.Dtos.Add(new Dto("Name1-1"));
            dto1.Dtos.Add(new Dto("Name1-2"));
            _dtos.Add(dto1);

            CTreeView.ItemsSource = _dtos;
        }
    }

    public sealed class Dto
    {
        public Dto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Dto> Dtos { get; set; } = new List<Dto>();
    }
}
