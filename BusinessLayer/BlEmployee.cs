using DataAccessLayer;
using System;
using System.Data;

namespace BusinessLayer
{
    public class BlEmployee
    {
        private DalEmployee _dalEmployee;
        public BlEmployee()
        {
            _dalEmployee = new DalEmployee();
        }
        public DataTable TabloSorgu(string Auth)
        {
            DataTable dataTable = _dalEmployee.KullaniciTablo(Auth);
            return dataTable;
        }
        public DataTable IlSorgu()
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.IlCekme();
            return dataTable;
        }
        public DataTable IlceSorgu(int ilID)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.IlceCekme(ilID);
            return dataTable;
        }
        public bool KullaniciAdBelirle(string Tc, string Ad)
        {
            bool onay = false;
            Random rnd = new Random(3);
            string parolasayi = rnd.Next().ToString();
            string kullaniciAd = Ad.Substring(3) + Tc.Substring(3);
            string kullaniciSifre = Ad.Substring(2) + Tc.Substring(2) + parolasayi;
            onay = _dalEmployee.EmployeeKullaniciAdBelirle(Tc, kullaniciAd, kullaniciSifre);
            return onay;
        }
        public bool EklemeSorgu(string Tc_No, string Ad, string Soyad, string Cinsiyet, string Kan_Grup, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            bool onay = false;
            onay = _dalEmployee.KullaniciEkle(Tc_No, Ad, Soyad, Cinsiyet, Kan_Grup, Telefon, Mail, Adres, IlID, IlceID);

            return onay;
        }
        public bool SilmeSorgu(string Tc_No)
        {
            bool onay = false;
            onay = _dalEmployee.KullaniciSil(Tc_No);

            return onay;
        }
        public bool GuncellemeSorgu(string Tc_No, string Ad, string Soyad, string Telefon, string Mail, string Adres, int IlID, int IlceID)
        {
            bool onay = false;
            onay = _dalEmployee.KullaniciGuncelle(Tc_No, Ad, Soyad, Telefon, Mail, Adres, IlID, IlceID);
            return onay;
        }
        public DataTable TcArama(string Tc_No)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.TcArama(Tc_No);
            return dataTable;
        }
        public DataTable AdSoyadArama(string Ad, string Soyad)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.AdSoyadArama(Ad, Soyad);
            return dataTable;
        }
        public DataTable TelArama(string Tel)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.TelArama(Tel);
            return dataTable;
        }
        public DataTable MailArama(string Mail)
        {
            DataTable dataTable = new DataTable();
            dataTable = _dalEmployee.MailArama(Mail);
            return dataTable;
        }
    }
}
