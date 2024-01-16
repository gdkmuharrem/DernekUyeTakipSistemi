using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityTblUserLogin
    {
        private string _kullaniciAd { get; set; }
        private string _kullaniciSifre { get; set; }
        private string _Auth {  get; set; }
        private string _Status { get; set; }

        public string kullaniciAd
        {
            get
            {
                return _kullaniciAd;
            }
            set
            {
                _kullaniciAd = value;
            }
        }
        public string kullaniciSifre
        {
            get
            {
                return _kullaniciSifre;
            }
            set
            {
                _kullaniciSifre = value;
            }
        }
        public string Auth
        {
            get
            {
                return _Auth;
            }
            set
            {
                _Auth = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

    }
}
