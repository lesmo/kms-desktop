﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KMS.Desktop.Localization {
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
    internal class ExceptionHandlingStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionHandlingStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("KMS.Desktop.Localization.ExceptionHandlingStrings", typeof(ExceptionHandlingStrings).Assembly);
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
        ///   Looks up a localized string similar to http://www.kms.me/es-MX/Software/Windows.
        /// </summary>
        internal static string AppDownloadLink {
            get {
                return ResourceManager.GetString("AppDownloadLink", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Por favor describe lo que hacías antes de que te sucediera este error&gt;
        ///--------
        ///Detalle técnico:.
        /// </summary>
        internal static string EmailBody {
            get {
                return ResourceManager.GetString("EmailBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [KMS para Windows] Error fatal.
        /// </summary>
        internal static string EmailSubject {
            get {
                return ResourceManager.GetString("EmailSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to lesmo@kms.me.
        /// </summary>
        internal static string EmailTo {
            get {
                return ResourceManager.GetString("EmailTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parece que nos ocurrió un error de dimensiones catastróficas en la App. Se generó un registro con detalles de este problema, y está listo para que nos lo envíes. Enviarnos éste reporte puede ayudarnos ENORMEMENTE a reparar lo que sea que haya causado ese problema.
        ///
        ///¿Quieres enviarlo ahora? Al dar click en Sí, abriremos tu cliente de correo electrónico donde podrás describir un poco más qué sucedió..
        /// </summary>
        internal static string MessageBoxText {
            get {
                return ResourceManager.GetString("MessageBoxText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BOOOM!.
        /// </summary>
        internal static string MessageBoxTitle {
            get {
                return ResourceManager.GetString("MessageBoxTitle", resourceCulture);
            }
        }
    }
}
