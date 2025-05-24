namespace Survey.Application.DTOs
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalCount { get; set; }  // Tüm veri sayısı
        public int PageNumber { get; set; }  // Şu anki sayfa
        public int PageSize { get; set; }    // Sayfa başı veri sayısı

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
    }
}
