using Kms.Interop.OAuth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace KMS.Desktop.Panels {
    class SortedIsoItems : SortedList<String, IsoItem> {
        public override string ToString() {
            return "";
        }
    }

    struct IsoItem : IEqualityComparer<IsoItem>, IEquatable<IsoItem>, IComparable<IsoItem> {
        public String Code;
        public String Name;
        
        public IsoItem(String code, String name) {
            Code = code;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }

        public Boolean Equals(IsoItem obj) {
            return Equals(this, obj);
        }

        public override bool Equals(Object obj) {
            if ( obj is IsoItem )
                return Equals((IsoItem)obj);
            else
                return false;
        }

        public override Int32 GetHashCode() {
            return GetHashCode(this);
        }

        public Int32 GetHashCode(IsoItem obj) {
            Int32 hashCode = 0;

            foreach ( var chr in obj.Code )
                hashCode += chr;

            return hashCode;
        }

        public Boolean Equals(IsoItem obj1, IsoItem obj2) {
            return obj1.Code.ToUpper() == obj2.Code.ToUpper();
        }

        public int CompareTo(IsoItem obj) {
            return this.Name.CompareTo(obj.Name);
        }
    }

    partial class RegisterPanel {
        private static SortedDictionary<IsoItem, SortedIsoItems> Geography {
            get;
            set;
        }

        private static BackgroundWorker m_geographyDownloader;
        private static EventHandler m_geographyDownloaderCallback;

        public static Boolean GeographyDownloaded {
            get;
            private set;
        }
        
        public static void DownloadGeography(EventHandler callback) {
            if ( GeographyDownloaded) {
                callback.Invoke(null, new EventArgs());
            } else {
                m_geographyDownloaderCallback = callback;
                m_geographyDownloader         = new BackgroundWorker();

                m_geographyDownloader.DoWork             += m_geographyDownloader_DoWork;
                m_geographyDownloader.RunWorkerCompleted += m_geographyDownloader_RunWorkerCompleted;
            
                m_geographyDownloader.RunWorkerAsync();
            }
        }

        static void m_geographyDownloader_DoWork(object sender, DoWorkEventArgs e) {
            Geography = new SortedDictionary<IsoItem, SortedIsoItems>();

            var response = Program.KmsCloudApi.RequestJsonArray(HttpRequestMethod.GET, "world").Response;

            foreach ( var country in response ) {
                var subdivisions = new SortedIsoItems();

                foreach ( var subdivision in country["Subdivisions"] ) {
                    try {
                        subdivisions.Add(
                            (String)subdivision["Name"],
                            new IsoItem(
                                (String)subdivision["Code"],
                                (String)subdivision["Name"]
                            )
                        );
                    } catch ( ArgumentException ) {
                    
                    }
                }

                Geography.Add(
                    new IsoItem(
                        (String)country["Code"], 
                        (String)country["Name"]
                    ),
                    subdivisions
                );
            }
        }

        static void m_geographyDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if ( e.Error == null ) {
                GeographyDownloaded = true;
                m_geographyDownloaderCallback.Invoke(null, new EventArgs());
            } else {
                throw e.Error;
            }
        }
    }
}
