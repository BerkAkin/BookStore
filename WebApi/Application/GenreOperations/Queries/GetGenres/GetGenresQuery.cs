using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetGenresQuery(IBookStoreDbContext bookStoreDbContext, IMapper mapper)
        {
            _context = bookStoreDbContext;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);
            return returnObj;
        }

    }

    public class GenresViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}