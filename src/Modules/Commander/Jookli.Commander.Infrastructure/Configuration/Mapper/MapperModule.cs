using Autofac;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Jookli.Commander.Infrastructure.Configuration.Mapper
{
    internal class MapperModule : Autofac.Module
    {
        private readonly IMapper _mapper;

        internal MapperModule()
        {
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper())
               .As<IMapper>()
               .SingleInstance();
        }
    }
}
