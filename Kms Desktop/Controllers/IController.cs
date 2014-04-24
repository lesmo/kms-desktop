using KMS.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KMS.Desktop.Controllers {
    public interface IController : IDisposable {
        UserControl ViewGeneric {
            get;
        }

        new void Dispose();
    }

    abstract class IController<T> : IController where T : UserControl {
        protected Main Main;
        
        public UserControl ViewGeneric {
            get {
                return (UserControl)this.View;
            }
        }

        public T View {
            get;
            private set;
        }

        public IController(Main main, T view) {
            this.Main = main;
            this.View = view;
        }

        public void Dispose() {
            this.View.Dispose();
        }
    }
}
