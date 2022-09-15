using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Queries.Files
{
    public class FileQueries : IFileQueries
    {
        private readonly AutoDocContext db;

        public FileQueries(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<FileDTO> GetFile(int id)
        {
            var file = await db.Files
                .Select(e => new FileDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    FileStatus = (FileStatuses)e.FileStatusId,
                    TaskId = e.TaskId
                })
                .FirstOrDefaultAsync(e => e.Id == id);

            return file;
        }

        public async Task<IEnumerable<FileDTO>> GetFiles(int take, int skip)
        {
            var file = await db.Files
                .Select(e => new FileDTO()
                {
                    Id = e.Id,
                    Name = e.Name,
                    FileStatus = (FileStatuses)e.FileStatusId,
                    TaskId = e.TaskId
                })
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return file;
        }
    }
}
