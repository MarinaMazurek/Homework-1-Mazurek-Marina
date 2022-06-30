using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public class AirCompany
    {
        public List<PassangerPlane> PassangerPlanes { get; set; }
        public List<FreightPlane> FreightPlanes { get; set; }

        public AirCompany(List<PassangerPlane> passangerPlanes, List<FreightPlane> freightPlanes)
        {
            PassangerPlanes = passangerPlanes;
            FreightPlanes = freightPlanes;
        }
    }
}
