﻿namespace MovieRatings.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MovieRatings.Data.Common.Repositories;
    using MovieRatings.Data.Models;

    public class GenresService : IGenresService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;

        public GenresService(IDeletableEntityRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.genresRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
