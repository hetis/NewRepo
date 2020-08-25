using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapperOdata.Models;
using DTOs.RequestModels;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace AutoMapperOdata.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class ClientContractController : ODataController
    {
        CMContext _context;
        IMapper _mapper;
        public ClientContractController(CMContext ctx, IMapper mapper )
        {
            _context = ctx;
            _mapper = mapper;
        }

        [EnableQuery(MaxExpansionDepth = 10)]
        public IQueryable<ClientContract> Get()
        {
            return _mapper.ProjectTo<ClientContract>(_context.ClientRefs)
                .Where(x => x.ValidFrom <= DateTime.Now && x.ValidTo >= DateTime.Now);
        }

    }
}
