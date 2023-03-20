using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using System.Collections.Concurrent;

namespace FileInfoChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<PhotoInfo> PhotoInfos { get; set; }

        private static readonly string[] ImageFormats =
            { ".tiff", ".jpeg", ".jpg", ".cals", ".bmp", ".png", ".pcx", ".gif" };

        public MainWindow()
        {
            InitializeComponent();
            PhotoInfos = new ObservableCollection<PhotoInfo>();
            PhotoGrid.ItemsSource = PhotoInfos;
        }

        private async void PathChooseButtonOnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            CurrentPath.Text = dialog.SelectedPath;
            PhotoInfos.Clear();
            await CheckNewPhotos(CurrentPath.Text);
        }

        private async Task CheckNewPhotos(string path)
        {
            try
            {
                await Task.Run(() =>
                {
                    Stopwatch watch = new Stopwatch();
                    watch.Start();
                    string[] allFiles = Directory.GetFiles(path)
                        .Where(p => ImageFormats.Contains(new FileInfo(p).Extension)).AsParallel().ToArray();
                    watch.Stop();

                    ParallelImagesProcessing(allFiles);

                    return Task.CompletedTask;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ParallelImagesProcessing(string[] allFiles)
        {
            if (allFiles.Length < 4)
            {
                foreach (var imagePath in allFiles)
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        PhotoInfos.Add(new PhotoInfo(imagePath));
                    });
                }

                return;
            }

            var infos = new ConcurrentBag<PhotoInfo>();

            int threadNumber = 4;
            int threadStep = allFiles.Length / threadNumber;
            Thread[] threads = new Thread[threadNumber];
            for (int i = 0; i < threadNumber - 1; ++i)
            {
                threads[i] =
                    new Thread(() => ImageProcessing(infos, allFiles[(i * threadStep)..((i + 1) * threadStep)]));
                threads[i].Start();
            }

            threads[^1] = new Thread(() =>
                ImageProcessing(infos, allFiles[((threadNumber - 1) * threadStep)..^1]));
            threads[^1].Start();

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                PhotoInfos = new ObservableCollection<PhotoInfo>(infos.ToArray());
                PhotoGrid.ItemsSource = PhotoInfos;
                CurrentPath.Text += $@", {PhotoInfos.Count} images found";
            });
            MessageBox.Show($"{PhotoInfos.Count}");
        }

        private void ImageProcessing(ConcurrentBag<PhotoInfo> photoInfos, string[] paths)
        {
            foreach (var path in paths)
            {
                photoInfos.Add(new PhotoInfo(path));
            }
        }
    }
}