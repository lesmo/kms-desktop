﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMS.Desktop {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class LocalizationStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizationStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KMS.Desktop.LocalizationStrings", typeof(LocalizationStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esperando dispositivo ....
        /// </summary>
        internal static string DownloadAgent_AwaitingDevice {
            get {
                return ResourceManager.GetString("DownloadAgent_AwaitingDevice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Conectando con servidores KMS ....
        /// </summary>
        internal static string DownloadAgent_ConnectingToCloud {
            get {
                return ResourceManager.GetString("DownloadAgent_ConnectingToCloud", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Descagando datos ....
        /// </summary>
        internal static string DownloadAgent_DownloadingData {
            get {
                return ResourceManager.GetString("DownloadAgent_DownloadingData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Iniciando descarga de datos ....
        /// </summary>
        internal static string DownloadAgent_InitializingDownload {
            get {
                return ResourceManager.GetString("DownloadAgent_InitializingDownload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Iniciando subida de datos ....
        /// </summary>
        internal static string UploadAgent_InitializingUpload {
            get {
                return ResourceManager.GetString("UploadAgent_InitializingUpload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subiendo datos ....
        /// </summary>
        internal static string UploadAgent_UploadingData {
            get {
                return ResourceManager.GetString("UploadAgent_UploadingData", resourceCulture);
            }
        }
    }
}
