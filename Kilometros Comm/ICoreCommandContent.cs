using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kilometros.Comm {
    public interface ICoreCommandContent {
        byte[] Serialize();
        void Deserialize(byte[] input);
    }
}
