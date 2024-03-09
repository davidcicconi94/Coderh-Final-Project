using coder.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coder.DataAccess.Data
{
    public partial class CoderDbContext: coderhouseContext
    {
        public CoderDbContext()
        {
            
        }

        public CoderDbContext(DbContextOptions<coderhouseContext> options)
                : base(options)
        {
        }
    }
}
