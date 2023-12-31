﻿using System.Threading.Tasks;
using System.Windows;

namespace WPF019
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ATextBlock.Text = AProgressBar.Value.ToString() + "%";
            BTextBlock.Text = BProgressBar.Value.ToString() + "%";
        }

        private void AProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ATextBlock.Text = AProgressBar.Value.ToString() + "%";
        }

        private void AButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>//別スレッドでの処理
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    Application.Current.Dispatcher.Invoke(() =>//UIスレッドに戻す構文
                    {
                        AProgressBar.Value += 10;//UIスレッドで行う処理のため、別スレッド上で実行するとエラーになる
                    });
                }
            });
        }

        private void BProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BTextBlock.Text = BProgressBar.Value.ToString() + "%";
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(500);

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        BProgressBar.Value += 10;
                    });
                }
            });
        }

        private void CButton_Click(object sender, RoutedEventArgs e)
        {
            CProgressBar.IsIndeterminate = true;
            CTextBlock.Text = "検索しています...";
        }
    }
}
