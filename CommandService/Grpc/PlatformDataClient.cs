using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandService.Grpc
{
    public class PlatformDataClient : IPlatformDataClient
    {
        private readonly IConfiguration _configuration;

        public PlatformDataClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<GrpcPlatformModel> ReturnAllPlatforms()
        {
            var channel = GrpcChannel.ForAddress(_configuration["GrpcPlatform"]);
            var client = new GrpcPlatform.GrpcPlatformClient(channel);
            var request = new GetAllRequests();

            try
            {
                var reply = client.GetAllPlatforms(request);
                return reply.Platform;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Could not call GRPC server");
                return null;
            }
        }
    }
}
