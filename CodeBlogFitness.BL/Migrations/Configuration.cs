using System.Data.Entity.Migrations;
using CodeBlogFitness.BL.Controller;

namespace CodeBlogFitness.BL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<FitnessContext>
    {
        public Configuration() => AutomaticMigrationsEnabled = true;

        protected override void Seed(FitnessContext context) {}
    }
}
