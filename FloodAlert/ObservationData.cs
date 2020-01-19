using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodAlert
{
    class ObservationData
    {
        public int id { get; set; }
        public int stationId { get; set; }
        public int waterLevel { get; set; }
        public DateTime measuringTime { get; set; }
        public DateTime processingTime { get; set; }
    }
}
