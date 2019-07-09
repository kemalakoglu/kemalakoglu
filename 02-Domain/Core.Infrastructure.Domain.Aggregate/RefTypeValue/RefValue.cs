using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Infrastructure.Domain.Aggregate;
using Core.Infrastructure.Domain.Aggregate.Base;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefValue:BaseEntity
    {
        public RefValue() { }
        public RefValue(string value, bool status, DateTime? insertDate, DateTime? updateDate, bool isActive, RefType refType)
        {
            this.Status = status;
            this.InsertDate = insertDate;
            this.UpdateDate = updateDate;
            this.Value = value;
            this.IsActive = isActive;
            this.RefType = refType;
        }
        public string Value { get; protected set; }
        public RefType RefType { get; protected set; }
    }
}
