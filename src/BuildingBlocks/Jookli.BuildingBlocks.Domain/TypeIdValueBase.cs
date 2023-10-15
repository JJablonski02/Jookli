﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Domain
{
    public abstract class TypeIdValueBase : IEquatable<TypeIdValueBase>
    {
        public Guid Value { get; }

        protected TypeIdValueBase(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidOperationException("Id value cannot be empty!");
            }
            Value = value;
        }
        public bool Equals(TypeIdValueBase? other)
        {
            return this.Value == other?.Value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TypeIdValueBase other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator == (TypeIdValueBase obj1, TypeIdValueBase obj2)
        {
            if(object.Equals(obj1, null))
            {
                if(object.Equals(obj2, null))
                {
                    return true;
                }
                return false;
            }
            return obj1.Equals(obj2);
        }

        public static bool operator != (TypeIdValueBase x, TypeIdValueBase y)
        {
            return !(x == y);
        }
    }
}
