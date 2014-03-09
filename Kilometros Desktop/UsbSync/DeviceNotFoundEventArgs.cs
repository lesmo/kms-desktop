using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kilometros_Desktop.UsbSync {
    enum DeviceNotFoundReason {
        MaxAttemptsReached,
        NotFoundOnUniqueAttempt,
        InnerCoreNotInCradle,
        Undefined
    }

    class DeviceNotFoundEventArgs : EventArgs {
        /// <summary>
        /// Determina si se alcanzó el límite máximo de intentos para buscar y encontrar un 
        /// KMS Inner Core, y fue la razón para lanzar éste evento.
        /// </summary>
        public readonly DeviceNotFoundReason NotFoundReason;

        public DeviceNotFoundEventArgs(DeviceNotFoundReason notFoundReason) {
            this.NotFoundReason = notFoundReason;
        }

        public static readonly new DeviceNotFoundEventArgs Empty
            = new DeviceNotFoundEventArgs(
                DeviceNotFoundReason.Undefined
            );
    }
}
