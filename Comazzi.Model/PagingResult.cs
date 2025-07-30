namespace Comazzi.Model
{
    public class PagingResult<T>
    {
        public int total { get; set; } = 0;

        public IEnumerable<T>? data { get; set; }
    }
}
