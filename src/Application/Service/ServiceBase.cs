using AutoMapper;

namespace AuthBack.src.Application.Service
{
    public abstract class ServiceBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        public ServiceBase(IMapper mapper, ILogger logger) 
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
