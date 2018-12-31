using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Expence_Tracker.ViewModel
{
    class GPS_Manager: INotifyPropertyChanged
    {
        private string _GPSPosition = "lost";
        private bool bPortOpen = false;
        private SerialPort port;
        private string serBuff = "";

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public string GPSPosition
        {
            get { return _GPSPosition; }
        }

        public void UpdateGPS()
        {
            port = new SerialPort("COM5", 4800);
            port.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
            port.Open();
            bPortOpen = true;
        }
        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool newData = false;
            serBuff = serBuff + port.ReadExisting();
            while (serBuff.Contains("\r\n"))
            {
                int i = serBuff.IndexOf("\r\n");
                string line = serBuff.Substring(0, i);
                if ('$' == line[0])
                    {
                    string[] tok = line.Split(',');
                    switch (tok[0])
                    {
                        case "$GPAPB":      
                            break;
                        case "$GPBOD":    
                            break;
                        case "$GPBWC": 
                            break;
                        case "$GPGGA": 
                            if (tok[1].Length > 0)
                            {
                                _GPSPosition =
                                    tok[2].Substring(0, 2) + " " + tok[2].Substring(2, tok[2].Length - 2) + " " + tok[3] +
                                     " – " +
                                    tok[4].Substring(0, 3) + " " + tok[4].Substring(3, tok[4].Length - 3) +
                                    " " + tok[5];
                            }
                            else
                            {
                                _GPSPosition = line;
                            }
                            newData = true;
                            break;
                        case "$GPGLL":      // Lat/Lon data
                            break;
                        case "$GPGSA":      //  Overall Satellite data
                            break;
                        case "$GPGSV":      // Detailed Satellite data
                                            //_GPSPosition = line;
                                            //newData = true;
                            break;
                        case "$GPRMB":      // recommended navigation data for gps
                            break;
                        case "$GPRMC":      // recommended minimum data for gps
                            break;
                        case "$GPRTE":      // route message
                            break;
                        case "$GPVTG":      // Vector track an Speed over the Ground
                            break;
                        case "$GPXTE":      // measured cross track error
                            break;
                        case "$PGRME":
                            break;
                        case "$PGRMM":
                            break;
                        case "$PGRMZ":
                            break;
                        default:
                            break;
                    }
                }
                serBuff = serBuff.Substring(i + 2);
            }
            
            if (newData)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("GPSPosition"));
                }
            }
        }
    }

    public class UpdatingDtTm : INotifyPropertyChanged
    {
        private string _someText = "Foo";
        private DispatcherTimer tmr = new DispatcherTimer();
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string FormattedDateTime
        {
            get { return _someText; }
        }

        public UpdatingDtTm()
        {
            tmr.Interval = TimeSpan.FromMilliseconds(10);
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            _someText = DateTime.Now.ToString();
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("FormattedDateTime"));
        }
    }
}
