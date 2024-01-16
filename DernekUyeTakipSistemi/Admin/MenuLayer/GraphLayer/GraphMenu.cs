using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace DernekUyeTakipSistemi.Admin.MenuLayer.GraphLayer.GraphMenu
{
    public partial class GraphMenu : Form
    {
        BlGraph _blGraph;
        string secilenYil;
        string secilenAy;
        int secilenIl;
        int secilenIlce;
        DataTable _dataTable;
        private bool uygulamaKapatildi = false;
        public GraphMenu()
        {
            InitializeComponent();
            _blGraph = new BlGraph();
            _dataTable = new DataTable();
            cb1.Visible = false;
            cb2.Visible = false;
            lb1.Visible = false;
            lb2.Visible = false;
            cbSec.SelectedIndex = 0;
        }
        private void ClearGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Grafik üzerindeki çizgileri ve çubukları temizle
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            // Eksenleri sıfırla
            myPane.XAxis.Title.Text = string.Empty;
            myPane.YAxis.Title.Text = string.Empty;
            myPane.Title.Text = string.Empty;

            // Eksen etiketlerini temizle
            myPane.XAxis.Scale.TextLabels = new string[] { };
            myPane.XAxis.Type = AxisType.Text;

            // Yeniden çizim ve geçersiz kılma
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void cbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGraph();
            if (cbSec.SelectedIndex == 1)
            {
                // Yıla göre gelir dağılımı
                cb1.Visible = true;
                cb2.Visible = false;
                lb1.Visible = true;
                lb2.Visible = false;
                lb1.Text = "Yil";
                YillariComboBoxaEkle();
            }
            if (cbSec.SelectedIndex == 2)
            {
                // Aya göre gelir dağılımı
                cb1.Visible = false;
                cb2.Visible = true;
                lb1.Visible = false;
                lb2.Visible = true;
                lb2.Text = "Ay";
                AylariComboBoxaEkle();
            }
            if (cbSec.SelectedIndex == 3)
            {
                cb1.Visible = true;
                cb2.Visible = true;
                lb1.Visible = true;
                lb2.Visible = true;
                lb1.Text = "Yil";
                lb2.Text = "Ay";
                YillariComboBoxaEkle();
                AylariComboBoxaEkle();
            }
            if (cbSec.SelectedIndex == 4)
            {
                cb1.Visible = true;
                cb2.Visible = false;
                lb1.Visible = true;
                lb2.Visible = false;
                lb1.Text = "İl";
                IlleriComboBoxaEkle();
            }
            if (cbSec.SelectedIndex == 5)
            {
                cb1.Visible = true;
                cb2.Visible = true;
                lb1.Visible = true;
                lb2.Visible = true;
                lb1.Text = "İl";
                lb2.Text = "İlçe";
                IlleriComboBoxaEkle();
            }
        }
        private void YillariComboBoxaEkle()
        {
            // Combobox'ı temizle
            cb1.DataSource = null;
            cb1.Items.Clear();

            // Yılları ekleyin
            for (int yil = 2005; yil <= 2030; yil++)
            {
                cb1.Items.Add(yil.ToString());
            }
        }
        private void AylariComboBoxaEkle()
        {
            // Combobox'ı temizle
            cb2.DataSource = null;
            cb2.Items.Clear();

            // Ayları ekleyin
            string[] aylar = new string[]
            {
                "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
                "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
            };

            cb2.Items.AddRange(aylar);
        }
        private void IlleriComboBoxaEkle()
        {
            cb1.DataSource = null;
            cb1.DisplayMember = null;
            cb1.ValueMember = null;
            cb1.SelectedIndex = -1;
            cb1.DataSource = _blGraph.IlSorgu();
            cb1.DisplayMember = "IlAdi";
            cb1.ValueMember = "IlID";
            cb1.SelectedIndex = -1;
        }
        private void IlceleriComboBoxaEkle(int IlID)
        {
            cb2.DataSource = null;
            cb2.DisplayMember = null;
            cb2.ValueMember = null;
            cb2.SelectedIndex = -1;
            cb2.DataSource = _blGraph.IlceSorgu(IlID);
            cb2.DisplayMember = "IlceAdi";
            cb2.ValueMember = "IlceID";
            cb2.SelectedIndex = -1;
        }
        private string GetFormattedMonthIndex(int selectedIndex)
        {
            // Seçilen index değerini bir arttır ve string olarak al
            int realIndex = selectedIndex + 1;
            string formattedIndex = realIndex.ToString();

            // Eğer değer 10'dan küçükse başına 0 ekle
            if (realIndex < 10)
            {
                formattedIndex = "0" + formattedIndex;
            }

            return formattedIndex;
        }
        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSec.SelectedIndex == 1)
            {
                secilenYil = cb1.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(secilenYil))
                {
                    // Tüm kullanıcıların aynı yıla ait borç bilgilerini çek
                    _dataTable = _blGraph.JustYil(secilenYil);
                    YilveyaAy("Yıl'a Göre Borç Bilgisi", "Ay", "Borç ve Aidat Miktarı", "AidatAy");
                }
            }
            if (cbSec.SelectedIndex == 3 && cb2.SelectedIndex != -1)
            {
                secilenYil = cb1.SelectedItem?.ToString();
                secilenAy = cb2.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(secilenYil) && !string.IsNullOrEmpty(secilenAy))
                {
                    string formattedAy = GetFormattedMonthIndex(cb2.SelectedIndex);
                    _dataTable = _blGraph.YilandAy(secilenYil, formattedAy);
                    YilveAy("Yıl ve Ay'a Göre Borç Bilgisi", "Kullanıcılar", "Borç ve Aidat Miktarı");
                }
            }
            if (cbSec.SelectedIndex == 4)
            {
                // İl seçili ise
                secilenIl = cb1.SelectedIndex;
                secilenIl++;
                _dataTable = _blGraph.IleGoreKSayi(secilenIl);
                IleGore("İL'e göre Kullanıcı Dağılımı", "Il", "Kullanıcı Sayısı", "IlAdi");
            }
            if (cbSec.SelectedIndex == 5)
            {
                DataRowView selectedRow = cb1.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    int selectedIlID = Convert.ToInt32(selectedRow["IlID"]);
                    IlceleriComboBoxaEkle(selectedIlID);
                }
            }
        }
        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSec.SelectedIndex == 2)
            {
                secilenAy = cb2.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(secilenAy))
                {
                    // Tüm kullanıcıların aynı yıla ait borç bilgilerini çek
                    string formattedAy = GetFormattedMonthIndex(cb2.SelectedIndex);
                    _dataTable = _blGraph.JustAy(formattedAy);
                    YilveyaAy("Ay'a Göre Borç Bilgisi", "Yıl", "Borç ve Aidat Miktarı", "AidatYil");
                }
            }
            if (cbSec.SelectedIndex == 3 && cb1.SelectedIndex != -1)
            {
                secilenYil = cb1.SelectedItem?.ToString();
                secilenAy = cb2.SelectedItem?.ToString();
                if (!string.IsNullOrEmpty(secilenYil) && !string.IsNullOrEmpty(secilenAy))
                {
                    string formattedAy = GetFormattedMonthIndex(cb2.SelectedIndex);
                    _dataTable = _blGraph.YilandAy(secilenYil, formattedAy);
                    YilveAy("Yıl ve Ay'a Göre Borç Bilgisi", "Kullanıcılar", "Borç ve Aidat Miktarı");
                }
            }
            if (cbSec.SelectedIndex == 5 && cb1.SelectedIndex != -1)
            {
                secilenIlce = cb2.SelectedIndex > 0 ? Convert.ToInt32(cb2.SelectedValue) : -1;
                _dataTable = _blGraph.IlceyeGoreKSayi(secilenIlce);
                IlceyeGore("İL ve İLÇEYE'e göre Kullanıcı Dağılımı", "Ilçe", "Kullanıcı Sayısı", "IlceAdi");
            }
        }
        private void YilveyaAy(string title, string xAxisTitle, string yAxisTitle, string groupByField)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xAxisTitle;
            myPane.YAxis.Title.Text = yAxisTitle;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            List<string> categories = new List<string>();
            List<double> borcBilgisi = new List<double>();
            List<double> aidatBilgisi = new List<double>();

            var groupedData = _dataTable.AsEnumerable()
                .GroupBy(row => row.Field<string>(groupByField))
                .Select(group => new
                {
                    Category = group.Key,
                    ToplamBorc = group.Sum(row => row.Field<int>("BorcMiktar")),
                    ToplamAidat = group.Sum(row => row.Field<int>("AidatTutar"))
                })
                .OrderBy(group => int.Parse(group.Category));

            // Gruplanmış veriyi al ve grafiğe ekle
            foreach (var group in groupedData)
            {
                categories.Add(group.Category);
                borcBilgisi.Add(group.ToplamBorc);
                aidatBilgisi.Add(group.ToplamAidat);
            }

            // Çizimi gerçekleştirin
            BarItem borcBarItem = myPane.AddBar("Borç Miktarı", null, borcBilgisi.ToArray(), Color.Blue);
            borcBarItem.Bar.Fill.Type = FillType.Solid;

            BarItem aidatBarItem = myPane.AddBar("Aidat Miktarı", null, aidatBilgisi.ToArray(), Color.Red);
            aidatBarItem.Bar.Fill.Type = FillType.Solid;

            // X ekseni etiketlerini ayarlama
            myPane.XAxis.Scale.TextLabels = categories.ToArray();
            myPane.XAxis.Type = AxisType.Text;

            // ZedGraphControl'u güncelleyin
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void YilveAy(string title, string xAxisTitle, string yAxisTitle)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xAxisTitle;
            myPane.YAxis.Title.Text = yAxisTitle;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            List<string> categories = new List<string>();
            List<double> borcBilgisi = new List<double>();
            List<double> odemeBilgisi = new List<double>();
            List<double> aidatBilgisi = new List<double>();

            var individualData = _dataTable.AsEnumerable()
                .Select(row => new
                {
                    Category = $"{row.Field<string>("Ad")} {row.Field<string>("Soyad")}",
                    Borc = row.Field<int>("BorcMiktar"),
                    Odeme = row.Field<int?>("OdemeMiktar") ?? 0,
                    Aidat = row.Field<int>("AidatTutar"),
                })
                .OrderBy(entry => entry.Category);

            // Gruplanmış veriyi al ve grafiğe ekle
            foreach (var entry in individualData)
            {
                categories.Add($"{entry.Category}");
                borcBilgisi.Add(entry.Borc);
                aidatBilgisi.Add(entry.Aidat);
                odemeBilgisi.Add(entry.Odeme);
            }

            double barWidth = 2;  // Çubuk genişliğini ayarla
            double barSpace = 10;  // Çubuklar arasındaki boşluğu ayarla

            // Çubukları temsil eden bir PointPairList oluştur
            PointPairList borcPoints = new PointPairList();
            PointPairList odemePoints = new PointPairList();
            PointPairList aidatPoints = new PointPairList();

            for (int i = 0; i < categories.Count; i++)
            {
                double xValue = i + 1;

                // Çubukların değerlerini PointPairList'e ekleyin
                borcPoints.Add(xValue, borcBilgisi[i]);
                odemePoints.Add(xValue + barWidth + barSpace, odemeBilgisi[i]);
                aidatPoints.Add(xValue + 2 * (barWidth + barSpace), aidatBilgisi[i]);
            }

            // Çubukları grafik pane'ine ekleyin
            BarItem borcBarItem = myPane.AddBar("Borç Miktarı", borcPoints, Color.Blue);
            borcBarItem.Bar.Fill.Type = FillType.Solid;

            BarItem aidatBarItem = myPane.AddBar("Aidat Miktarı", aidatPoints, Color.Red);
            aidatBarItem.Bar.Fill.Type = FillType.Solid;

            BarItem odemeBarItem = myPane.AddBar("Ödeme Miktarı", odemePoints, Color.Green);
            odemeBarItem.Bar.Fill.Type = FillType.Solid;

            // X ekseni etiketlerini ayarlama
            myPane.XAxis.Scale.TextLabels = categories.ToArray();
            myPane.XAxis.Type = AxisType.Text;

            // ZedGraphControl'u güncelleyin
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void IleGore(string title, string xAxisTitle, string yAxisTitle, string groupByField)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xAxisTitle;
            myPane.YAxis.Title.Text = yAxisTitle;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            List<string> categories = new List<string>();
            List<double> kullaniciSayisi = new List<double>();

            // Gruplanmış veriyi al ve grafiğe ekle
            foreach (DataRow row in _dataTable.Rows)
            {
                string category = row.Field<string>(groupByField);
                double userCount = Convert.ToDouble(row["KullaniciSayisi"]);
                categories.Add(category);
                kullaniciSayisi.Add(userCount);
            }

            // Çizimi gerçekleştirin
            BarItem kullaniciBarItem = myPane.AddBar("Kullanıcı Sayısı", null, kullaniciSayisi.ToArray(), Color.Green);
            kullaniciBarItem.Bar.Fill.Type = FillType.Solid;

            // X ekseni etiketlerini ayarlama
            myPane.XAxis.Scale.TextLabels = categories.ToArray();
            myPane.XAxis.Type = AxisType.Text;

            // ZedGraphControl'u güncelleyin
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void IlceyeGore(string title, string xAxisTitle, string yAxisTitle, string groupByField)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xAxisTitle;
            myPane.YAxis.Title.Text = yAxisTitle;
            myPane.CurveList.Clear();
            myPane.GraphObjList.Clear();

            List<string> categories = new List<string>();
            List<double> kullaniciSayisi = new List<double>();

            // Gruplanmış veriyi al ve grafiğe ekle
            foreach (DataRow row in _dataTable.Rows)
            {
                string category = row.Field<string>(groupByField);
                double userCount = Convert.ToDouble(row["KullaniciSayisi"]);
                categories.Add(category);
                kullaniciSayisi.Add(userCount);
            }

            // Çizimi gerçekleştirin
            BarItem kullaniciBarItem = myPane.AddBar("Kullanıcı Sayısı", null, kullaniciSayisi.ToArray(), Color.Green);
            kullaniciBarItem.Bar.Fill.Type = FillType.Solid;

            // X ekseni etiketlerini ayarlama
            myPane.XAxis.Scale.TextLabels = categories.ToArray();
            myPane.XAxis.Type = AxisType.Text;

            // ZedGraphControl'u güncelleyin
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            uygulamaKapatildi = true;
            this.Close();
            AMenu aMenu = Application.OpenForms["AMenu"] as AMenu;
            aMenu?.Show();
        }
        private void GraphMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!uygulamaKapatildi)
            {
                DialogResult cikis = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    uygulamaKapatildi = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}

