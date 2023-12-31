﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfTeamDal : GenericRepository<Team>, ITeamDal
    {
        public int GetTeamCount()
        {
            using var context = new AgricultureContext();

            int teamCount = context.Teams.Count();

            return teamCount;
        }
    }
}
