using AutoMapper;
using AutoMapperOdata.Models;
using DTOs.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AutoMapperOdata
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ClientRef, ClientContract>().
            ForMember(dest => dest.ValidFrom,
            opt =>
            {
                opt.MapFrom(y => y.Clients.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).ValidFrom);
            }).
            ForMember(dest => dest.ValidTo,
            opt =>
            {
                opt.MapFrom(y => y.Clients.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).ValidTo);
            }).
           ForMember(dest => dest.FirstName,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).FirstName);
            }).
            ForMember(dest => dest.LastName,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).LastName);
            }).
            ForMember(dest => dest.BirthDate,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).BirthDate);
            }).
            ForMember(dest => dest.FatherName,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).FatherName);
            }).
            ForMember(dest => dest.CompanyName,
            opt =>
            {
                opt.MapFrom(y => y.Companies.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).CompanyName);

            })
            .
            ForMember(dest => dest.PinNumber,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).Pin);

            }).
            ForMember(dest => dest.Position,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).Position);

            }).
            ForMember(dest => dest.PositionCustom,
            opt =>
            {
                opt.MapFrom(y => y.PhysicalPeople.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).PositionCustom);

            }).
            ForMember(dest => dest.ClientType,
            opt =>
            {
                opt.MapFrom(y => y.Clients.FirstOrDefault(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).ClientType);

            })
            .
            ForMember(dest => dest.Documents,
            opt =>
            {
                opt.MapFrom(y => y.Documents.Where(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now));
                //opt.ExplicitExpansion();
            })
            .ForMember(dest => dest.ContactsInfo,
            opt =>
            {
                opt.MapFrom(y => y.ClientContactInfoComps.Where(x => x.ValidFrom <= DateTime.Now && x.ValidTo > DateTime.Now).Select(x => x.ContactInfo));
                //opt.ExplicitExpansion();
            }).
            ForMember(dest => dest.ClientComment,
            opt =>
            {
                opt.MapFrom(y => y.CommentComps.Where(x => x.Contact == null).Select(x => x.Comment));
                //opt.ExplicitExpansion();
            }).
            ForMember(dest => dest.Relations,
            opt =>
            {
                opt.MapFrom(y => y.ClientRelationCompClient1Navigations);
                //opt.ExplicitExpansion();
            })
            ;


            CreateMap<Document, DocumentContract>();

            CreateMap<ContactInfo, ContactInfoContract>().
            ForMember(dest => dest.ContactComments,
            opt =>
            {
            opt.MapFrom(y => y.CommentComps.Select(x => x.Comment));
            });

            CreateMap<ClientRelationComp, RelationContract>().
                ForMember(dest => dest.ClientINN,
                opt => {
                    opt.MapFrom(x => x.Client2);
                }).
                ForMember(dest => dest.RelationType,
                opt => {
                    opt.MapFrom(x => x.RelationId);
                });

            CreateMap<ICollection<Client>, ClientContract>();
            CreateMap<ICollection<PhysicalPerson>, ClientContract>();
            CreateMap<ICollection<Company>, ClientContract>();
            CreateMap<Comment, CommentContract>();
            CreateMap<ICollection<Comment>, ICollection<ContactInfoContract>>();
            CreateMap<ICollection<ClientRelationComp>, ClientRef>();
            
        }
    }
}
