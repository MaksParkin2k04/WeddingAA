using Microsoft.EntityFrameworkCore;
using Wedding.Models;

namespace Wedding.Data {
    public class WeddingRepository : IWeddingRepository {
        public WeddingRepository(ApplicationContext context) {
            this.context = context;
        }

        private readonly ApplicationContext context;

        public async Task<Models.Wedding?> GetByAlias(string alias) {
            return await context.Weddings.Include(w => w.WeddingEvents).AsNoTracking().FirstOrDefaultAsync(w => w.Alias == alias);
        }

        public async Task<Models.Wedding?> GetById(Guid wddingId) {


            return await context.Weddings.Include(w => w.WeddingEvents).Include(w => w.Messages).OrderBy(m => m.WeddingDate).FirstOrDefaultAsync(w => w.Id == wddingId);
        }

        public async Task Update(Models.Wedding wedding) {
            context.Weddings.Update(wedding);
            await context.SaveChangesAsync();
        }
    }
}
