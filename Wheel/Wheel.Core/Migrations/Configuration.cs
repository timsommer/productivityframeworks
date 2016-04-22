namespace Wheel.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Wheel.Core.WheelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Wheel";
        }

        protected override void Seed(Wheel.Core.WheelContext context)
        {
            
        }
    }
}
