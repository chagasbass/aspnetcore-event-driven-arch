﻿using Aspnetcore.EDA.SharedContext.Base.Entities;

namespace Aspnetcore.EDA.Inventory.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
