﻿using System;
using System.Runtime.Serialization;

namespace Lending.Core.Model
{
    [DataContract]
    public abstract class Ownership
    {
        [DataMember]
        public virtual Guid Id { get; protected set; }

        [DataMember]
        public virtual Item Item { get; protected set; }

        protected Ownership()
        {
        }

        public Ownership(Item item)
        {
            Item = item;
        }

        public abstract int OwnerId { get; }

        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return Id.Equals(((Ownership) obj).Id);

        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }

    [DataContract]
    public class Ownership<T> : Ownership where T : IOwner
    {
        [DataMember]
        public virtual T Owner { get; protected set; }

        public override int OwnerId
        {
            get { return Owner.Id; }
        }

        protected Ownership()
        {
        }

        public Ownership(Item item, T owner)
            : base(item)
        {
            Owner = owner;
        }

    }

}
