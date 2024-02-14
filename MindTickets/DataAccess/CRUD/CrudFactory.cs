﻿using DataAccess.DAO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public abstract class CrudFactory
    {
        protected SqlDAO dao;

        //Definicion de los metodos del CRUD.

        public abstract void Create(BaseDTO dto);

        public abstract T Retrieve<T>();

		public abstract T Retrieve<T>(BaseDTO dto);

		public abstract T RetrieveById<T>(int Id);

        public abstract List<T> RetrieveAll<T>();

        public abstract void Update(BaseDTO dto);
        public abstract void Delete(BaseDTO dto);

		//SI SE REQUIEREN MAS PARA TODO EL CRUD SE AGREGA AQUI:
		public abstract void DeleteID(int Id);

		public abstract void AddImages(BaseDTO dto);

		public abstract void Create(BaseDTO dto, BaseDTO dto1);
	}
}
