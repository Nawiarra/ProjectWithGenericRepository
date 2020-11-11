﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoodWorkshop.Data.Interfaces;
using WoodWorkshop.Data.Models;

namespace WoodWorkshop.Data.Repositories
{
    public class WoodWorkshopRepository : IWoodWorkshopRepository
    {
        private readonly MigrationContext _ctx;

        public WoodWorkshopRepository()
        {
            _ctx = new MigrationContext();
        }
        public WoodFurnitureOrder Create(WoodFurnitureOrder model)
        {
            _ctx.WoodFurnitureOrders.Add(model);

            _ctx.SaveChanges();

            return model;
        }

        public List<WoodFurnitureOrder> GetAll()
        {
            return _ctx.WoodFurnitureOrders.ToList();
        }

        public WoodFurnitureOrder GetById(int id)
        {
            return _ctx.WoodFurnitureOrders.FirstOrDefault(x => x.Id == id);
        }

        public List<WoodFurnitureOrder> GetAllByCustomerId(int id)
        {
            return _ctx.WoodFurnitureOrders
                .Where(x => x.CustomerId == id)
                .ToList();
        }

        public WoodFurnitureOrder UpdateItem(WoodFurnitureOrder model)
        {
            var entity = GetById(model.Id);
            entity.Id = model.Id;
            entity.CustomerId = model.CustomerId;
            entity.Customer = model.Customer;
            entity.Date = model.Date;
            entity.Color = model.Color;
            entity.FurnitureType = model.FurnitureType;
            entity.FurnitureTypeId = model.FurnitureTypeId;
            entity.WoodTypeId = model.WoodTypeId;
            entity.WoodType = model.WoodType;

            _ctx.SaveChanges();

            return model;
        }

        public bool DeleteItem(WoodFurnitureOrder model)
        {
            try
            {
                var entity = GetById(model.Id);

                _ctx.WoodFurnitureOrders.Remove(entity);
                _ctx.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
