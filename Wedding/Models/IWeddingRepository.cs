namespace Wedding.Models {
    public interface IWeddingRepository {
        Task<Wedding?> GetById(Guid wddingId);
        Task<Wedding?> GetByAlias(string alias);

        Task Update(Wedding wedding);
    }
}
