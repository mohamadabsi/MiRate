﻿using System;
using AutoMapper;
using Framework.Core.Extensions;

namespace Framework.Core.AutoMapper
{
    public class AutoMapAttribute : AutoMapAttributeBase
    {
        public AutoMapAttribute(params Type[] targetTypes) : base(targetTypes)
        {

        }

        public override void CreateMap(IMapperConfigurationExpression configuration, Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                configuration.CreateMap(type, targetType, MemberList.Source);
                configuration.CreateMap(targetType, type, MemberList.Destination);
            }
        }
    }
}