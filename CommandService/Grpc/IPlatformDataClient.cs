using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.Grpc
{
    public interface IPlatformDataClient
    {
        IEnumerable<GrpcPlatformModel> ReturnAllPlatforms();
    }
}
