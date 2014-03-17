﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMS.Desktop.Views.Events {
    struct RegisterData {
        public string Name;
        public string LastName;
        public string Email;
        public DateTime BirthDate;

        public string RegionCode;
        public char Gender;
        public int Height;
        public int Weight;
    }

    class RegisterContinueEventArgs : EventArgs {
        public RegisterData RegisterData {
            get;
            private set;
        }

        public RegisterContinueEventArgs(RegisterData data) {
            this.RegisterData
                = data;
        }
    }
}