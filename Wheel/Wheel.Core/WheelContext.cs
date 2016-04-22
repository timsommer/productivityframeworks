using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wheel.Core
{
    public class WheelContext : DbContext
    {
        public WheelContext() : base("Name=Wheel")
        {   
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
