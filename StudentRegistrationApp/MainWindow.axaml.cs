using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.ObjectModel;

namespace StudentRegistrationApp
{
    public partial class MainWindow : Window
    {
        // Menyimpan data mahasiswa agar sinkron dengan ListBox
        private readonly ObservableCollection<string> daftarMahasiswa = new();

        public MainWindow()
        {
            InitializeComponent();
            lstMahasiswa.ItemsSource = daftarMahasiswa;
        }

        private void BtnSimpan_Click(object? sender, RoutedEventArgs e)
        {
            // Validasi NIM
            if (string.IsNullOrWhiteSpace(txtNim.Text))
            {
                TampilkanPesan("NIM harus diisi!", Colors.Red);
                txtNim.Focus();
                return;
            }

            // Validasi Nama
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                TampilkanPesan("Nama harus diisi!", Colors.Red);
                txtNama.Focus();
                return;
            }

            // Validasi Program Studi
            if (cmbProdi.SelectedItem is not ComboBoxItem itemProdi)
            {
                TampilkanPesan("Pilih program studi!", Colors.Red);
                return;
            }
            string prodi = itemProdi.Content?.ToString() ?? "";

            // Validasi Jenis Kelamin
            string jenisKelamin = "";
            if (rbLaki.IsChecked == true)
            {
                jenisKelamin = "Laki-laki";
            }
            else if (rbPerempuan.IsChecked == true)
            {
                jenisKelamin = "Perempuan";
            }
            else
            {
                TampilkanPesan("Pilih jenis kelamin!", Colors.Red);
                return;
            }

            // Simpan data ke ListBox
            string data = $"{txtNim.Text} | {txtNama.Text} | {prodi} | {jenisKelamin}";
            daftarMahasiswa.Add(data);

            TampilkanPesan("Data mahasiswa berhasil disimpan!", Colors.Green);
            ResetInput();
        }

        private void BtnReset_Click(object? sender, RoutedEventArgs e)
        {
            ResetInput();
            txtPesan.Text = string.Empty;
        }

        private void BtnHapus_Click(object? sender, RoutedEventArgs e)
        {
            if (lstMahasiswa.SelectedItem is string dataTerpilih)
            {
                daftarMahasiswa.Remove(dataTerpilih);
                TampilkanPesan("Data berhasil dihapus.", Colors.Green);
            }
            else
            {
                TampilkanPesan("Pilih data yang ingin dihapus!", Colors.Red);
            }
        }

        private void ResetInput()
        {
            txtNim.Text = string.Empty;
            txtNama.Text = string.Empty;
            cmbProdi.SelectedIndex = -1;
            rbLaki.IsChecked = false;
            rbPerempuan.IsChecked = false;
            txtNim.Focus();
        }

        private void TampilkanPesan(string pesan, Color warna)
        {
            txtPesan.Text = pesan;
            txtPesan.Foreground = new SolidColorBrush(warna);
        }
    }
}
