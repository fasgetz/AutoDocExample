using AutoDoc.DataBase.ContextDb;
using AutoDoc.Infrastructure.Models.DTO.Files;
using AutoDoc.Infrastructure.Models.DTO.Task;
using AutoDoc.Infrastructure.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDoc.Infrastructure.Application.Queries.Tasks
{
    public class TaskQueries : ITaskQueries
    {
        private readonly AutoDocContext db;

        public TaskQueries(AutoDocContext db)
        {
            this.db = db;
        }

        public async Task<TaskDTO> GetTask(int id)
        {
            var task = await db.Tasks.Select(e => new TaskDTO()
            {
                Id = e.Id,
                Name = e.Name,
                CreatedDate = e.CreatedDate,
                FileTask = (TaskStatuses)e.TaskStatusId,
                Files = e.Files.Select(f => new FileDTO()
                {
                    Id = f.Id,
                    Name = f.Name,
                    FileStatus = (FileStatuses)f.FileStatusId,
                    TaskId = e.Id
                }).ToList()
            }).FirstOrDefaultAsync(e => e.Id == id);

            return task;
        }

        public async Task<IEnumerable<TaskDTO>> GetTasks(int take, int skip)
        {
            var tasks = await db.Tasks.Select(e => new TaskDTO()
            {
                Id = e.Id,
                Name = e.Name,
                CreatedDate = e.CreatedDate,
                FileTask = (TaskStatuses)e.TaskStatusId,
                Files = e.Files.Select(f => new FileDTO()
                {
                    Id = f.Id,
                    Name = f.Name,
                    FileStatus = (FileStatuses)f.FileStatusId,
                    TaskId = e.Id
                }).ToList()
            }).Skip(skip).Take(take).ToListAsync();

            return tasks;
        }
    }
}
