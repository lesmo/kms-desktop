using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KMS.Desktop.Utils {
    internal static class UriExpansion {
        private static Regex QuerySplit = new Regex(@"[\#\?]");

        public static NameValueCollection ParseQueryStringToNameValue(this Uri @this, bool hideEmptyValues = false) {
            var nameValueReturn = new NameValueCollection();
            var queryParts      = UriExpansion.QuerySplit.Split(@this.AbsoluteUri, 2);
            
            if ( queryParts.Length != 2 )
                return nameValueReturn;

            var queryItems = queryParts[1].Split(new char[]{'&'});
            foreach ( var item in queryItems ) {
                var keyValue = item.Split(new char[]{ '=' }, 2);

                if ( keyValue.Length == 2 ) {
                    if ( !(hideEmptyValues && string.IsNullOrEmpty(keyValue[1])) )
                        nameValueReturn.Add(keyValue[0], keyValue[1]);
                } else if ( keyValue.Length == 1 && ! hideEmptyValues ) {
                    nameValueReturn.Add(keyValue[0], null);
                }
            }

            return nameValueReturn;
        }
    }
}
