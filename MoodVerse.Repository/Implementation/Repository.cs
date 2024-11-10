using MoodVerse.Repository.Interface;

namespace MoodVerse.Repository.Implementation
{
    public class Repository(ApplicationDbContext context) : IRepository
    {
        protected ApplicationDbContext Context { get; } = context;

        public async Task SaveChanges() => await Context.SaveChangesAsync();
    }
}
