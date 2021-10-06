using AutoMapper;
using Grpc.Core;
using PlatformService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.gRPC
{
    public class GRpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;

        public GRpcPlatformService(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public override async Task<PlatformResponse> GetAllPlatforms(GetAllRequests request, ServerCallContext context )
        {
            var response = new PlatformResponse();
            var platforms = await _repo.GetAllPlatforms();

            foreach (var platform in platforms)
            {
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(platform));
            }

            return response;
        }
    }
}
