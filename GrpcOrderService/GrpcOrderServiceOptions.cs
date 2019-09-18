using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcOrderService
{
    public class GrpcOrderServiceOptions
    {
        public Uri GrpcOrderServiceAddres { get; set; }
        public bool IsHttps
        {
            get
            {
                return GrpcOrderServiceAddres != null && GrpcOrderServiceAddres.Scheme == Uri.UriSchemeHttps;
            }
        }
    }
}
