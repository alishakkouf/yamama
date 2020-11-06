using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yamama.Repository
{
   public  interface IProject
    {
        Task <List<Project>> GetProjects();
        Task <Project> GetProject(int id);
        Task <int> AddProjectAsync(Project project);
        Task <int> UpdateProject(int id, Project project);
        Task <int> DeleteProjectAsync(int id);
    }
}
