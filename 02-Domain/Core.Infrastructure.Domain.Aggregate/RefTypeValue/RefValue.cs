﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Core.Infrastructure.Domain.Aggregate;
using Core.Infrastructure.Domain.Aggregate.Base;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core.Infrastructure.Domain.Aggregate.RefTypeValue
{
    public class RefValue:BaseEntity
    {
        private readonly ILazyLoader lazyLoader;
        public RefValue() { }
        public RefValue(ILazyLoader lazyLoader)
        {
            this.lazyLoader = lazyLoader;
        }
        public RefValue(string value, bool status, DateTime? insertDate, DateTime? updateDate, bool isActive, RefType refType, string name)
        {
            this.Status = status;
            this.InsertDate = insertDate;
            this.UpdateDate = updateDate;
            this.Value = value;
            this.IsActive = isActive;
            this.RefType = refType;
            this.Name = name;
        }

        public RefValue(string value, bool status, DateTime? insertDate, DateTime? updateDate, bool isActive, RefType refType, string name, string description, string image, string imageText)
        {
            this.Status = status;
            this.InsertDate = insertDate;
            this.UpdateDate = updateDate;
            this.Value = value;
            this.IsActive = isActive;
            this.RefType = refType;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.ImageText = imageText;
        }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Value { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Image { get; protected set; }
        public string ImageText { get; protected set; }
        public RefType RefType
        {
            get => lazyLoader.Load(this, ref refType);
            set => refType = value;
        }

        public RefType refType;
        public void SetStatus(bool status)
        {
            this.Status = status;
        }
        public void Update(string name, bool isActive, RefType refType, string value, string description, string image, string imageText)
        {
            this.Name = name;
            this.RefType = refType;
            this.IsActive = isActive;
            this.UpdateDate= DateTime.Now;
            this.Value = value;
            this.Description = description;
            this.Image = image;
            this.ImageText = imageText;
        }
    }
}
