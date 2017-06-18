namespace Makaki.Data.Seeder
{
    public interface ISeeder
    {
        void Seed(DatabaseContext context);
    }
}
